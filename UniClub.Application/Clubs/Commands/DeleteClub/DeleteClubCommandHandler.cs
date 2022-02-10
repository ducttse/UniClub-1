using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.Clubs.Commands.DeleteClub
{
    public class DeleteClubCommandHandler : IRequestHandler<DeleteClubCommand, int>
    {
        private readonly IClubRepository _clubRepository;

        public DeleteClubCommandHandler(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<int> Handle(DeleteClubCommand request, CancellationToken cancellationToken)
        {
            return await _clubRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
