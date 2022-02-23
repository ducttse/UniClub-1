using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateClubRoleCommandHandler : IRequestHandler<UpdateClubRoleDto, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public UpdateClubRoleCommandHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubRoleDto request, CancellationToken cancellationToken)
        {
            return await _clubRoleRepository.UpdateAsync(_mapper.Map<ClubRole>(request), cancellationToken);
        }
    }
}
