using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class ClubPeriodRepository : CRUDRepository<ClubPeriod, int>, IClubPeriodRepository
    {
        public ClubPeriodRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubPeriods;
        }

        protected override DbSet<ClubPeriod> DbSet { get; }

        protected override IQueryable<ClubPeriod> Search(IQueryable<ClubPeriod> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                        || e.Status.ToString().Equals(searchValue));

        protected override IQueryable<ClubPeriod> InTime(IQueryable<ClubPeriod> query, DateTime? startDate, DateTime? endDate)
        {
            if (startDate != null && endDate != null)
            {
                return query.Where(e => startDate <= e.StartDate && e.EndDate <= endDate);
            }

            if (startDate != null)
            {
                return query.Where(e => startDate <= e.StartDate);
            }
            if (endDate != null)
            {
                return query.Where(e => e.EndDate <= endDate);
            }
            return query;
        }
    }
}
