using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteUniversityCommandHandler : IRequestHandler<DeleteUniversityDto, int>
    {
        private readonly IUniversityRepository _universityRepository;

        public DeleteUniversityCommandHandler(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<int> Handle(DeleteUniversityDto request, CancellationToken cancellationToken)
        {
            return await _universityRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
