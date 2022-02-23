using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteClubPeriodCommandHandler : IRequestHandler<DeleteClubPeriodDto, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;

        public DeleteClubPeriodCommandHandler(IClubPeriodRepository clubPeriodRepository)
        {
            _clubPeriodRepository = clubPeriodRepository;
        }

        public async Task<int> Handle(DeleteClubPeriodDto request, CancellationToken cancellationToken)
        {
            return await _clubPeriodRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
