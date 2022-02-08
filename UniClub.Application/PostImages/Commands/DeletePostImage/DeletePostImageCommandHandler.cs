using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.PostImages.Commands.DeletePostImage
{
    public class DeletePostImageCommandHandler : IRequestHandler<DeletePostImageCommand, int>
    {
        private readonly IPostImageRepository _postImageRepository;

        public DeletePostImageCommandHandler(IPostImageRepository postImageRepository)
        {
            _postImageRepository = postImageRepository;
        }

        public async Task<int> Handle(DeletePostImageCommand request, CancellationToken cancellationToken)
        {
            return await _postImageRepository.HardDeleteAsync(request.Id, cancellationToken);
        }
    }
}
