using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniClub.Domain.Common.Interfaces;

namespace UniClub.Domain.Common
{
    public abstract class AuditableEntity<TKey> : AuditableEntity, IEntity, IEntity<TKey>, IMayHaveCreator, IHasCreationTime, IMayHaveModifier, IHasModificationTime, ISoftDelete
    {
        [Key]
        public TKey Id { get; set; }
    }

    public abstract class AuditableEntity : IEntity, IMayHaveCreator, IHasCreationTime, IMayHaveModifier, IHasModificationTime, ISoftDelete
    {
        [MaxLength(300)]
        public virtual string CreatedBy { get; set; }
        public virtual DateTime CreationTime { get; set; }
        [MaxLength(300)]
        public string LastModifiedBy { get; set; }
        public DateTime ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public bool IsHardDeleted { get; set; }
    }
}
