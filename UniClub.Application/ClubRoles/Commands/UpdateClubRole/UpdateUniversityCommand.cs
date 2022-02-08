using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Application.ClubRoles.Commands.UpdateClubRole
{
    public class UpdateClubRoleCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }
        public int ClubPeriodId { get; set; }
    }
}
