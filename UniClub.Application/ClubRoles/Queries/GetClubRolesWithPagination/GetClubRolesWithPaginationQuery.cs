using MediatR;
using UniClub.Application.ClubRoles.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.ClubRoles.Queries.GetClubRolesWithPagination
{
    public class GetClubRolesWithPaginationQuery : IRequest<PaginatedList<ClubRoleDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
