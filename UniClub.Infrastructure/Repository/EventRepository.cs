using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IApplicationDbContext _context;

        public EventRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Event entity, CancellationToken cancellationToken)
        {
            var e = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (e == null)
                {
                    _context.Events.Add(entity);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("Event has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteAsync(Event entity, CancellationToken cancellationToken)
        {
            var e = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (e == null)
                {
                    _context.Events.Remove(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("Event has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Event> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _context.Events.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public async Task<PaginatedList<Event>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            List<Event> result = new();
            int count = 0;
            try
            {
                count = await _context.Events.CountAsync(cancellationToken);
                result = await _context.Events.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            return new PaginatedList<Event>(result, count, pageNumber, pageSize);
        }

        public async Task<int> UpdateAsync(Event entity, CancellationToken cancellationToken)
        {
            Event e = await GetByIdAsync(entity.Id, cancellationToken);

            try
            {
                if (e != null)
                {
                    _context.Events.Update(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("Event has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
