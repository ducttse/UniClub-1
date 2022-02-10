using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class MemberRepository : CRUDRepository<Member, int>, IMemberRepository
    {
        public MemberRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Members;
        }

        protected override DbSet<Member> DbSet { get; }

        protected override IQueryable<Member> Search(IQueryable<Member> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                        || e.StudentId.ToString().Equals(searchValue)
                                        || e.JoinDate.ToString().Equals(searchValue)
                                        || e.ClubId.ToString().Equals(searchValue));
    }
}
