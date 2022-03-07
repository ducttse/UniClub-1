using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Update.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventDto, int>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateEventDto request, CancellationToken cancellationToken)
        {
            var entity = await _eventRepository.GetByIdAsync(cancellationToken, new UpdateEventCommandSpecification(request));
            return await _eventRepository.UpdateAsync(entity, _mapper.Map<Event>(request), cancellationToken);
        }
    }
}
