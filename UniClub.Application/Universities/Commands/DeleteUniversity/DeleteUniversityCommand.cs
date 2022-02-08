using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Universities.Commands.DeleteUniversity
{
    public class DeleteUniversityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteUniversityCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteUniversityCommandHandler : IRequestHandler<DeleteUniversityCommand, int>
    {
        private readonly IUniversityRepository _universityRepository;

        public DeleteUniversityCommandHandler(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<int> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
        {
            return await _universityRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
