using MediatR;
using System;
using UniClub.Application.ClubTasks.Dtos;
using UniClub.Application.Common;
using UniClub.Domain.Common;

namespace UniClub.Application.ClubTasks.Queries.GetClubTasksWithPagination
{
    public class GetClubTasksWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<ClubTaskDto>>
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
