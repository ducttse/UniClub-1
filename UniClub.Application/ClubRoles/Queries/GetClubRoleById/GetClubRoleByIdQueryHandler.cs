using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.ClubRoles.Dtos;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubRoles.Queries.GetClubRoleById
{
    public class GetClubRoleByIdQueryHandler : IRequestHandler<GetClubRoleByIdQuery, ClubRoleDto>
    {
        private readonly IClubRoleRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetClubRoleByIdQueryHandler(IClubRoleRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }
        public async Task<ClubRoleDto> Handle(GetClubRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubRoleDto>(await _universityRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
