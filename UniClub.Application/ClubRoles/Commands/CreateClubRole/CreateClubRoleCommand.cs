using MediatR;

namespace UniClub.Application.ClubRoles.Commands.CreateClubRole
{
    public class CreateClubRoleCommand : IRequest<int>
    {
        public int ClubId { get; set; }
        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }
        public int ClubPeriodId { get; set; }
    }
}
