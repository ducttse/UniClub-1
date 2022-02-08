using MediatR;

namespace UniClub.Application.PostImages.Commands.CreatePostImage
{
    public class CreatePostImageCommand : IRequest<int>
    {
        public int PostId { get; set; }
        public string ImageUrl { get; set; }
    }
}
