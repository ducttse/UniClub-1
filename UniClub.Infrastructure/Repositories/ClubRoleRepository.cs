using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class ClubRoleRepository : CRUDRepository<ClubRole, int>, IClubRoleRepository
    {
        public ClubRoleRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubRoles;
        }

        protected override DbSet<ClubRole> DbSet { get; }

        protected override IQueryable<ClubRole> Search(IQueryable<ClubRole> query, string searchValue)
             => query.Where(e => e.Id.ToString().Equals(searchValue)
                                    || e.Role.Contains(searchValue)
                                    || e.ReportToRoleId.ToString().Equals(searchValue));
    }
}
