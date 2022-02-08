using MediatR;
using UniClub.Application.Clubs.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Clubs.Queries.GetClubsWithPagination
{
    public class GetClubsWithPaginationQuery : IRequest<PaginatedList<ClubDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
