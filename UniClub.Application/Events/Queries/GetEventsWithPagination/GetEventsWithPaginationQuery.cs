using MediatR;
using System;
using UniClub.Application.Common;
using UniClub.Application.Events.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Events.Queries.GetEventsWithPagination
{
    public class GetEventsWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<EventDto>>
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
