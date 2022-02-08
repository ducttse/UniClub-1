using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.PostImages.Commands.CreatePostImage
{
    public class CreatePostImageCommandQueryHandler : IRequestHandler<CreatePostImageCommand, int>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public CreatePostImageCommandQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePostImageCommand request, CancellationToken cancellationToken)
        {
            return await _postImageRepository.CreateAsync(_mapper.Map<PostImage>(request), cancellationToken);
        }
    }
}
