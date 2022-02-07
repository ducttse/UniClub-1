#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class PostImage
    {
        public int ImageId { get; set; }
        public int PostId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Post Post { get; set; }
    }
}
