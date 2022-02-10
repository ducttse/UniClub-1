using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubRoles.Commands.UpdateClubRole
{
    public class UpdateClubRoleCommandHandler : IRequestHandler<UpdateClubRoleCommand, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public UpdateClubRoleCommandHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubRoleCommand request, CancellationToken cancellationToken)
        {
            return await _clubRoleRepository.UpdateAsync(_mapper.Map<ClubRole>(request), cancellationToken);
        }
    }
}
