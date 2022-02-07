using System;
using System.Collections.Generic;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class Member : AuditableEntity<int>
    {
        public Member()
        {
            MemberRoles = new HashSet<MemberRole>();
        }

        public string StudentId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClubId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Person Student { get; set; }
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
