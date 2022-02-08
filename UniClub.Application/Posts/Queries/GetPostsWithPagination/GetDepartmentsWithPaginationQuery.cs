using MediatR;
using UniClub.Application.Posts.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Posts.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQuery : IRequest<PaginatedList<PostDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
