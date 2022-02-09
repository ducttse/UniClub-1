using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Interfaces;

namespace UniClub.Application.Common
{
    public abstract class CRUDRepository<T, TKey> : ICRUDRepository<T, TKey> where T : AuditableEntity<TKey>
    {
        private readonly IApplicationDbContext _context;
        protected abstract DbSet<T> DbSet { get; }

        public CRUDRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken)
            => await DbSet.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
        public async Task<(List<T> Items, int Count)> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            List<T> result = new();
            int count = 0;
            try
            {
                count = await DbSet.CountAsync(cancellationToken);
                result = await DbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            return (result, count);
        }
        public virtual async Task<int> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            var e = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (e == null)
                {
                    DbSet.Add(entity);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception($"{nameof(entity)} - ID:{entity.Id.ToString()} has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            T e = await GetByIdAsync(entity.Id, cancellationToken);

            try
            {
                if (e != null)
                {
                    DbSet.Update(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception($"{nameof(entity)} - ID:{entity.Id.ToString()} is invalid");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> DeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            T entity = await GetByIdAsync(id, cancellationToken);
            try
            {
                if (entity != null)
                {
                    DbSet.Remove(entity);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("Object has not existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<int> HardDeleteAsync(TKey id, CancellationToken cancellationToken)
        {
            T entity = await GetByIdAsync(id, cancellationToken);
            try
            {
                if (entity != null)
                {
                    entity.IsHardDeleted = true;
                    DbSet.Remove(entity);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("Object has not existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
            => await DbSet.ToListAsync();
    }
}
