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
    public class ClubTaskRepository : IClubTaskRepository
    {
        private readonly IApplicationDbContext _context;

        public ClubTaskRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(ClubTask entity, CancellationToken cancellationToken)
        {
            var clubTask = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (clubTask == null)
                {
                    _context.ClubTasks.Add(entity);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("ClubTask has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteAsync(ClubTask entity, CancellationToken cancellationToken)
        {
            var clubTask = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (clubTask == null)
                {
                    _context.ClubTasks.Remove(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("ClubTask has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClubTask> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _context.ClubTasks.FirstOrDefaultAsync(clubTask => clubTask.Id == id, cancellationToken);

        public async Task<PaginatedList<ClubTask>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            List<ClubTask> result = new();
            int count = 0;
            try
            {
                count = await _context.ClubTasks.CountAsync(cancellationToken);
                result = await _context.ClubTasks.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            return new PaginatedList<ClubTask>(result, count, pageNumber, pageSize);
        }

        public async Task<int> UpdateAsync(ClubTask entity, CancellationToken cancellationToken)
        {
            ClubTask clubTask = await GetByIdAsync(entity.Id, cancellationToken);

            try
            {
                if (clubTask != null)
                {
                    _context.ClubTasks.Update(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("ClubTask has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}