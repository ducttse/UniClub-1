using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.HardDelete.Handlers
{
    public class DeletePostImageCommandHandler : IRequestHandler<DeletePostImageDto, int>
    {
        private readonly IPostImageRepository _postImageRepository;

        public DeletePostImageCommandHandler(IPostImageRepository postImageRepository)
        {
            _postImageRepository = postImageRepository;
        }

        public async Task<int> Handle(DeletePostImageDto request, CancellationToken cancellationToken)
        {
            return await _postImageRepository.HardDeleteAsync(request.Id, cancellationToken);
        }
    }
}
