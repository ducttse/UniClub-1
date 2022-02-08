using MediatR;
using UniClub.Application.Posts.Dtos;

namespace UniClub.Application.Posts.Queries.GetPostWithId
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public int Id { get; set; }
        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
    }
}
