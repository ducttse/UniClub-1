using System;
using System.Collections.Generic;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class Post : AuditableEntity<int>
    {
        public Post()
        {
            PostImages = new HashSet<PostImage>();
        }

        public string PersonId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShortDescription { get; set; }
        public int? EventId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
