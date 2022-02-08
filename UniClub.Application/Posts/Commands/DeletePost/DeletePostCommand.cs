using MediatR;

namespace UniClub.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
