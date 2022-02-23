using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateEventDtoQueryHandler : IRequestHandler<CreateEventDto, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventDtoQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEventDto request, CancellationToken cancellationToken)
        {
            return await _eventRepository.CreateAsync(_mapper.Map<Event>(request), cancellationToken);
        }
    }
}
