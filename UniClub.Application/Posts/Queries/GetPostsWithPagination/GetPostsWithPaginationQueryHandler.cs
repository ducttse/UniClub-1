using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Helpers;
using UniClub.Application.Posts.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.Posts.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQueryHandler : IRequestHandler<GetPostsWithPaginationQuery, PaginatedList<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsWithPaginationQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PostDto>> Handle(GetPostsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                request.OrderBy = new PostDto().HasProperty(request.OrderBy);
            }
            var result = await _postRepository.GetListAsync(cancellationToken, new GetPostsWithPaginationSpecification(request));
            return new PaginatedList<PostDto>(result.Items.Select(e => _mapper.Map<PostDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
