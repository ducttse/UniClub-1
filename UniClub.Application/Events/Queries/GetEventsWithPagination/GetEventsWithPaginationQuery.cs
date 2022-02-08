using MediatR;
using UniClub.Application.Events.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Events.Queries.GetEventsWithPagination
{
    public class GetEventsWithPaginationQuery : IRequest<PaginatedList<EventDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
