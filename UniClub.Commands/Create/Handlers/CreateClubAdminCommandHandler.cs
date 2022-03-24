using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Domain.Common.Enums;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Services.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubAdminCommandHandler : IRequestHandler<CreateClubAdminDto, string>
    {
        private const string DEFAULT_FEMALE_IMAGE = "https://firebasestorage.googleapis.com/v0/b/premium-client-337312.appspot.com/o/users%2Fdefaultfemaleprofile.jpg?alt=media&token=a6a7febf-1682-424f-a2e9-a37acd25c458";
        private const string DEFAULT_MALE_IMAGE = "https://firebasestorage.googleapis.com/v0/b/premium-client-337312.appspot.com/o/users%2Fdefaultmaleprofile.jpg?alt=media&token=3bf73995-3ec1-4565-8a0f-93cf540777fb8";

        private readonly IIdentityService _identityService;
        private readonly UserManager<Person> _userManager;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public CreateClubAdminCommandHandler(IIdentityService identityService, UserManager<Person> userManager, IUploadService uploadService, IMapper mapper)
        {
            _identityService = identityService;
            _userManager = userManager;
            _uploadService = uploadService;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateClubAdminDto request, CancellationToken cancellationToken)
        {
            string imageUrl = string.Empty;
            if (request.UploadedImage != null && request.UploadedImage.Length > 0)
            {
                imageUrl = await _uploadService.Upload(request.UploadedImage, "users");
            }
            if (string.IsNullOrEmpty(imageUrl))
            {
                if (request.Gender.HasValue && request.Gender.Value)
                {
                    imageUrl = DEFAULT_MALE_IMAGE;
                }
                else
                {
                    imageUrl = DEFAULT_FEMALE_IMAGE;
                }
            }
            request.ImageUrl = imageUrl;
            var x = _mapper.Map<Person>(request);
            var result = await _identityService.CreateUserAsync(_mapper.Map<Person>(request), request.Password);
            await _identityService.AddToRoleAsync(result.UserId, Role.ClubAdmin.ToString());

            var claim = new Claim("club", $"{request.ClubId}-{ClubRole.President}");
            var user = await _userManager.FindByIdAsync(result.UserId);

            await _userManager.AddClaimAsync(user, claim);
            return result.UserId;
        }
    }
}
