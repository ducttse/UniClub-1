using System;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class MemberRole
    {
        public int MemberId { get; set; }
        public int ClubRoleId { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ClubRole ClubRole { get; set; }
        public virtual Member Member { get; set; }
    }
}
