using MediatR;
using UniClub.Application.ClubRoles.Dtos;
using UniClub.Application.Common;
using UniClub.Domain.Common;

namespace UniClub.Application.ClubRoles.Queries.GetClubRolesWithPagination
{
    public class GetClubRolesWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<ClubRoleDto>>
    {
    }
}
