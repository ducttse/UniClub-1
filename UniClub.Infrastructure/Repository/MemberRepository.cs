using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class MemberRepository : CRUDRepository<Member, int>, IMemberRepository
    {
        public MemberRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Members;
        }

        protected override DbSet<Member> DbSet { get; }
    }
}
