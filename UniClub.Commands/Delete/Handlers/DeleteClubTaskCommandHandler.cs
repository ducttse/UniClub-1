using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteClubTaskCommandHandler : IRequestHandler<DeleteClubTaskDto, int>
    {
        private readonly IClubTaskRepository _clubTaskRepository;

        public DeleteClubTaskCommandHandler(IClubTaskRepository clubTaskRepository)
        {
            _clubTaskRepository = clubTaskRepository;
        }

        public async Task<int> Handle(DeleteClubTaskDto request, CancellationToken cancellationToken)
        {
            return await _clubTaskRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
