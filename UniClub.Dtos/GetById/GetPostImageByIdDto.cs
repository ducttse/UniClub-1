using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetPostImageByIdDto : IRequest<PostImageDto>
    {
        public int Id { get; }
        public int PostId { get; }
        public GetPostImageByIdDto(int postId, int id)
        {
            PostId = postId;
            Id = id;
        }
    }
}
