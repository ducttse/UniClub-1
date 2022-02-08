using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniClub.Domain.Common.Interfaces;

namespace UniClub.Domain.Common
{
    public abstract class AuditableEntity<TKey> : IEntity<TKey>, IMayHaveCreator, IHasCreationTime, IMayHaveModifier, IHasModificationTime, ISoftDelete
    {
        [Key]
        public TKey Id { get; set; }
        [MaxLength(300)]
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        [MaxLength(300)]
        public string LastModifiedBy { get; set; }
        public DateTime ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public bool IsHardDeleted { get; set; }
    }
}
