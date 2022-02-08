using MediatR;

namespace UniClub.Application.ClubPeriods.Commands.DeleteClubPeriod
{
    public class DeleteClubPeriodCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteClubPeriodCommand(int id)
        {
            Id = id;
        }
    }
}
