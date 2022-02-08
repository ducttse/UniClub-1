using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class ClubPeriodRepository : CRUDRepository<ClubPeriod, int>, IClubPeriodRepository
    {
        public ClubPeriodRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubPeriods;
        }

        protected override DbSet<ClubPeriod> DbSet { get; }
    }
}
