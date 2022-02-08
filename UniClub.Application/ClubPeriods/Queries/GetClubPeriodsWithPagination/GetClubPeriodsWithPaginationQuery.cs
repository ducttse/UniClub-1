using MediatR;
using UniClub.Application.ClubPeriods.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.ClubPeriods.Queries.GetClubPeriodsWithPagination
{
    public class GetClubPeriodsWithPaginationQuery : IRequest<PaginatedList<ClubPeriodDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
