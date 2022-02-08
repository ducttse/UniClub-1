using MediatR;

namespace UniClub.Application.PostImages.Commands.DeletePostImage
{
    public class DeletePostImageCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeletePostImageCommand(int id)
        {
            Id = id;
        }
    }
}
