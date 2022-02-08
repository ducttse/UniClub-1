using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;

        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<int> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            return await _eventRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
