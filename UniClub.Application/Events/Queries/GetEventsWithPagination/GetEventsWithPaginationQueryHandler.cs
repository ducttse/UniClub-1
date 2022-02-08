using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Events.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Events.Queries.GetEventsWithPagination
{
    public class GetEventsWithPaginationQueryHandler : IRequestHandler<GetEventsWithPaginationQuery, PaginatedList<EventDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventsWithPaginationQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EventDto>> Handle(GetEventsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _eventRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new PaginatedList<EventDto>(result.Items.Select(e => _mapper.Map<EventDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
