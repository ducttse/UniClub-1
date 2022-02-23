using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentDto, Result>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateStudentDto request, CancellationToken cancellationToken)
        {
            return await _identityService.UpdateUserAsync(_mapper.Map<Person>(request));
        }
    }
}
