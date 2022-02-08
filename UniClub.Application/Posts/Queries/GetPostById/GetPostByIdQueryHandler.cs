using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Posts.Dtos;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PostDto>(await _postRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
