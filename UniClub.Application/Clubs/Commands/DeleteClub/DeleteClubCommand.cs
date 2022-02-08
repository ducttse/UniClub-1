using MediatR;

namespace UniClub.Application.Clubs.Commands.DeleteClub
{
    public class DeleteClubCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteClubCommand(int id)
        {
            Id = id;
        }
    }
}
