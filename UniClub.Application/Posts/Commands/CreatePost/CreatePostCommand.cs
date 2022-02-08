using MediatR;
using UniClub.Domain.Common.Enums;

namespace UniClub.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>
    {
        public string PersonId { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        public string ShortDescription { get; set; }
        public int? EventId { get; set; }
    }
}
