using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverUserCommandHandler : IRequestHandler<RecoverUserDto, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RecoverUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(RecoverUserDto request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByIdAsync(cancellationToken, new RecoverUserCommandSpecification(request));
            if (entity == null)
            {
                throw new Exception("Not found deleted entity");
            }
            return await _userRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
