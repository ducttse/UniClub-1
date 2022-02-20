using MediatR;
using System;
using UniClub.Application.ClubTasks.Dtos;
using UniClub.Application.Common;
using UniClub.Domain.Common;

namespace UniClub.Application.ClubTasks.Queries.GetClubTasksWithPagination
{
    public class GetClubTasksWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<ClubTaskDto>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
