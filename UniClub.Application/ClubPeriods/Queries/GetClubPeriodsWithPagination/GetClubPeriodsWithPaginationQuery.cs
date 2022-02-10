using MediatR;
using System;
using UniClub.Application.ClubPeriods.Dtos;
using UniClub.Application.Common;
using UniClub.Domain.Common;

namespace UniClub.Application.ClubPeriods.Queries.GetClubPeriodsWithPagination
{
    public class GetClubPeriodsWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<ClubPeriodDto>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
