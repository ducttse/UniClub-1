using System;
using System.Collections.Generic;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class ClubPeriod
    {
        public ClubPeriod()
        {
            ClubRoles = new HashSet<ClubRole>();
        }
        public int ClubPeriodId { get; set; }
        public int ClubId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Club Club { get; set; }
        public virtual ICollection<ClubRole> ClubRoles { get; set; }
    }
}
