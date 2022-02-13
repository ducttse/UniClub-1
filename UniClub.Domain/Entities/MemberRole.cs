using System;
using UniClub.Domain.Common.Enums;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class MemberRole
    {
        public string MemberId { get; set; }
        public int ClubRoleId { get; set; }
        public MemberRoleStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClubPeriodId { get; set; }

        public virtual ClubPeriod ClubPeriod { get; set; }
        public virtual ClubRole ClubRole { get; set; }
        public virtual Person Member { get; set; }
    }
}
