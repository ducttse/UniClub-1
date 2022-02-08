using MediatR;
using UniClub.Application.ClubRoles.Dtos;

namespace UniClub.Application.ClubRoles.Queries.GetClubRoleById
{
    public class GetClubRoleByIdQuery : IRequest<ClubRoleDto>
    {
        public int Id { get; set; }
        public GetClubRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
