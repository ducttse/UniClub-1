using System.Collections.Generic;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class ClubRole : AuditableEntity<int>
    {
        public ClubRole()
        {
            InverseReportToRole = new HashSet<ClubRole>();
            MemberRoles = new HashSet<MemberRole>();
        }

        public int ClubId { get; set; }
        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }
        public int ClubPeriodId { get; set; }

        public virtual Club Club { get; set; }
        public virtual ClubRole ReportToRole { get; set; }
        public virtual ClubPeriod ClubPeriod { get; set; }
        public virtual ICollection<ClubRole> InverseReportToRole { get; set; }
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
