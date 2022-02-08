using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class EventRepository : CRUDRepository<Event, int>, IEventRepository
    {
        public EventRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Events;
        }

        protected override DbSet<Event> DbSet { get; }
    }
}
