using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Exceptions;
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

        public virtual async Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken, bool isDelete = false)
        => isDelete ? await DbSet.FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken)
            : await DbSet.FirstOrDefaultAsync(e => e.Id.Equals(id) && !e.IsDeleted, cancellationToken);


        public virtual async Task<(List<T> Items, int Count)> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string searchValue = null, string orderBy = null, bool IsAscending = true, bool isDelete = false, DateTime? startDate = null, DateTime? endDate = null)
        {
            List<T> result = new();
            int count = 0;
            try
            {
                IQueryable<T> query = null;

                if (!isDelete)
                {
                    query = query == null ? query = DbSet.Where(e => !e.IsDeleted) : query.Where(e => !e.IsDeleted);
                }

                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    query = Search(query, searchValue);
                }

                if (startDate != null || endDate != null)
                {
                    query = InTime(query, startDate, endDate);
                }

                if (!string.IsNullOrWhiteSpace(orderBy))
                {
                    query = IsAscending ? query = query.OrderBy(orderBy) : query = query.OrderBy($"{orderBy} descending");
                }

                if (query == null)
                {
                    count = await DbSet.CountAsync(cancellationToken);
                    result = await DbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
                }
                else
                {
                    count = await query.CountAsync(cancellationToken);
                    result = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
                }

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
                    throw new NotFoundException(nameof(entity), entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            T inDatabase = await GetByIdAsync(entity.Id, cancellationToken);

            try
            {
                if (inDatabase != null)
                {
                    UpdateEntityWithInDatabase(inDatabase, entity);
                    _context.Entry(inDatabase).Property(e => e.Id).IsModified = false;
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new NotFoundException(nameof(entity), entity);
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
                    throw new NotFoundException(nameof(entity), entity);
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
                    throw new NotFoundException(nameof(entity), entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<List<T>> GetAllWithoutPaginationAsync(CancellationToken cancellationToken)
            => await DbSet.Where(e => e.IsDeleted == false).ToListAsync();

        protected abstract IQueryable<T> Search(IQueryable<T> query, string searchValue);

        protected virtual IQueryable<T> InTime(IQueryable<T> query, DateTime? startDate, DateTime? endDate) => query;

        private void UpdateEntityWithInDatabase(T inDatabase, T entity)
        {
            foreach (var inDatabaseProperty in inDatabase.GetType().GetProperties())
            {
                if (!inDatabaseProperty.Name.Equals("Id"))
                {
                    entity.GetType().GetProperty(inDatabaseProperty.Name).SetValue(inDatabase, inDatabaseProperty.GetValue(entity));
                }
            }
        }
    }
}
