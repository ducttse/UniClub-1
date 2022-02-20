using MediatR;
using UniClub.Application.Common;
using UniClub.Application.Posts.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Posts.Queries.GetPostsWithPagination
{
    public class GetPostsWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<PostDto>>
    {
    }
}
