using MediatR;
using UniClub.Application.ClubTasks.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.ClubTasks.Queries.GetClubTasksWithPagination
{
    public class GetClubTasksWithPaginationQuery : IRequest<PaginatedList<ClubTaskDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
