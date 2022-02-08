using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.ClubPeriods.Commands.DeleteClubPeriod
{
    public class DeleteClubPeriodCommandHandler : IRequestHandler<DeleteClubPeriodCommand, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;

        public DeleteClubPeriodCommandHandler(IClubPeriodRepository clubPeriodRepository)
        {
            _clubPeriodRepository = clubPeriodRepository;
        }

        public async Task<int> Handle(DeleteClubPeriodCommand request, CancellationToken cancellationToken)
        {
            return await _clubPeriodRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
