using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class ClubTaskRepository : CRUDRepository<ClubTask, int>, IClubTaskRepository
    {
        public ClubTaskRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubTasks;
        }

        protected override DbSet<ClubTask> DbSet { get; }

        protected override IQueryable<ClubTask> Search(IQueryable<ClubTask> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                    || e.EventId.ToString().Equals(searchValue)
                                    || e.Status.ToString().Equals(searchValue)
                                    || e.TaskName.Contains(searchValue)
                                    || e.Description.Contains(searchValue));

        protected override IQueryable<ClubTask> InTime(IQueryable<ClubTask> query, DateTime? startDate, DateTime? endDate)
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
