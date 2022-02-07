#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class EventByClub
    {
        public int ClubId { get; set; }
        public int EventId { get; set; }
        public bool IsHost { get; set; }

        public virtual Club Club { get; set; }
        public virtual Event Event { get; set; }
    }
}
