using System;
using System.Collections.Generic;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class Club : AuditableEntity<int>
    {
        public Club()
        {
            ClubPeriods = new HashSet<ClubPeriod>();
            ClubRoles = new HashSet<ClubRole>();
            EventByClubs = new HashSet<EventByClub>();
            Members = new HashSet<Member>();
        }

        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Slogan { get; set; }

        public virtual University Uni { get; set; }
        public virtual ICollection<ClubPeriod> ClubPeriods { get; set; }
        public virtual ICollection<ClubRole> ClubRoles { get; set; }
        public virtual ICollection<EventByClub> EventByClubs { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
