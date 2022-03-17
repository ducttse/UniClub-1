using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;
using UniClub.Services.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityDto, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public CreateUniversityCommandHandler(IUniversityRepository universityRepository, IUploadService uploadService, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _uploadService = uploadService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUniversityDto request, CancellationToken cancellationToken)
        {
            string logoUrl = null;
            if (request.UploadedLogo != null && request.UploadedLogo.Length > 0)
            {
                logoUrl = await _uploadService.Upload(request.UploadedLogo, "universities");
            }
            request.LogoUrl = logoUrl;
            return await _universityRepository.CreateAsync(_mapper.Map<University>(request), cancellationToken);
        }
    }
}
