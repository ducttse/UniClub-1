using MediatR;
using UniClub.Application.Clubs.Dtos;
using UniClub.Application.Common;
using UniClub.Domain.Common;

namespace UniClub.Application.Clubs.Queries.GetClubsWithPagination
{
    public class GetClubsWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<ClubDto>>
    {
    }
}
