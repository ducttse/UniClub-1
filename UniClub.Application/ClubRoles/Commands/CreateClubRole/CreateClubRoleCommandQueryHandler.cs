using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubRoles.Commands.CreateClubRole
{
    public class CreateClubRoleCommandQueryHandler : IRequestHandler<CreateClubRoleCommand, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public CreateClubRoleCommandQueryHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubRoleCommand request, CancellationToken cancellationToken)
        {
            return await _clubRoleRepository.CreateAsync(_mapper.Map<ClubRole>(request), cancellationToken);
        }
    }
}
