using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Infrastructure.Repository
{
    public class ClubRoleRepository
    {
        private readonly IApplicationDbContext _context;

        public ClubRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(ClubRole entity, CancellationToken cancellationToken)
        {
            var clubRole = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (clubRole == null)
                {
                    _context.ClubRoles.Add(entity);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("ClubRole has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteAsync(ClubRole entity, CancellationToken cancellationToken)
        {
            var clubRole = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (clubRole == null)
                {
                    _context.ClubRoles.Remove(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("ClubRole has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClubRole> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _context.ClubRoles.FirstOrDefaultAsync(clubRole => clubRole.Id == id, cancellationToken);

        public async Task<PaginatedList<ClubRole>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            List<ClubRole> result = new();
            int count = 0;
            try
            {
                count = await _context.ClubRoles.CountAsync(cancellationToken);
                result = await _context.ClubRoles.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            return new PaginatedList<ClubRole>(result, count, pageNumber, pageSize);
        }

        public async Task<int> UpdateAsync(ClubRole entity, CancellationToken cancellationToken)
        {
            ClubRole clubRole = await GetByIdAsync(entity.Id, cancellationToken);

            try
            {
                if (clubRole != null)
                {
                    _context.ClubRoles.Update(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("ClubRole has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}