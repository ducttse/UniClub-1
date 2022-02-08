using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class ClubTaskRepository : CRUDRepository<ClubTask, int>, IClubTaskRepository
    {
        public ClubTaskRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubTasks;
        }

        protected override DbSet<ClubTask> DbSet { get; }
    }
}
