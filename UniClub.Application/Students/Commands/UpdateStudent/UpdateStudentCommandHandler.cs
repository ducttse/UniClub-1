using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;
using UniClub.Application.Models;
using UniClub.Domain.Entities;

namespace UniClub.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Result>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.UpdateUserAsync(_mapper.Map<Person>(request));
        }
    }
}
