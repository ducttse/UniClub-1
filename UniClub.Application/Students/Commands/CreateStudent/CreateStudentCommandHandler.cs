using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;

namespace UniClub.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, string>
    {
        private readonly string STUDENT_ROLE = "Student";
        private readonly IIdentityService _identityService;
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IIdentityService identityService, UserManager<Person> userManager, IMapper mapper)
        {
            _identityService = identityService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(_mapper.Map<Person>(request), request.Password);
            await _identityService.AddToRoleAsync(result.UserId, STUDENT_ROLE);
            return result.UserId;
        }
    }
}
