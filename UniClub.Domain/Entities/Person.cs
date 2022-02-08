using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UniClub.Domain.Common.Interfaces;

namespace UniClub.Domain.Entities
{
    public class Person : IdentityUser, IMayHaveCreator, IHasCreationTime, IMayHaveModifier, IHasModificationTime, ISoftDelete
    {
        public Person()
        {
            Id = Guid.NewGuid().ToString();
            SecurityStamp = Guid.NewGuid().ToString();

            Members = new HashSet<Member>();
            Participants = new HashSet<Participant>();
            Posts = new HashSet<Post>();
            StudentInTasks = new HashSet<StudentInTask>();
        }
        public override string Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? DepId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public bool IsHardDeleted { get; set; }

        public virtual Department Dep { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<StudentInTask> StudentInTasks { get; set; }
    }
}
