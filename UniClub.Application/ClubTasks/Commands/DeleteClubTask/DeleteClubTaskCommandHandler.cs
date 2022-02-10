using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubTasks.Commands.DeleteClubTask
{
    public class DeleteClubTaskCommandHandler : IRequestHandler<DeleteClubTaskCommand, int>
    {
        private readonly IClubTaskRepository _clubTaskRepository;

        public DeleteClubTaskCommandHandler(IClubTaskRepository clubTaskRepository)
        {
            _clubTaskRepository = clubTaskRepository;
        }

        public async Task<int> Handle(DeleteClubTaskCommand request, CancellationToken cancellationToken)
        {
            return await _clubTaskRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
