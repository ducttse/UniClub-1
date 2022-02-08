using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;

namespace UniClub.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, string>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(_mapper.Map<Person>(request), request.Password);
            return result.UserId;
        }
    }
}
