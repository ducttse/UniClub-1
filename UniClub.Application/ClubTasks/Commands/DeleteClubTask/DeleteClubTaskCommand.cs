using MediatR;

namespace UniClub.Application.ClubTasks.Commands.DeleteClubTask
{
    public class DeleteClubTaskCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteClubTaskCommand(int id)
        {
            Id = id;
        }
    }
}
