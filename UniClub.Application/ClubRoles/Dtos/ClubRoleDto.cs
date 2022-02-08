namespace UniClub.Application.ClubRoles.Dtos
{
    public class ClubRoleDto
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }
        public int ClubPeriodId { get; set; }
    }
}
