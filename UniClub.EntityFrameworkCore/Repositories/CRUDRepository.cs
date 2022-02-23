using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Exceptions;
using UniClub.Domain.Common.Interfaces;
using UniClub.Repositories.Interfaces;
using UniClub.Specifications;
using UniClub.Specifications.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public abstract class CRUDRepository<T, TKey> : ICRUDRepository<T, TKey> where T : AuditableEntity<TKey>
    {
        private readonly IApplicationDbContext _context;
        protected abstract DbSet<T> DbSet { get; }

        public CRUDRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken, ISpecification<T> specification = null)
        => await SpecificationEvaluator<T>.GetQuery(DbSet.Where(e => e.Id.Equals(id))
            .AsQueryable(), specification).FirstOrDefaultAsync();

        public virtual async Task<(List<T> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<T> specification = null)
        {
            List<T> result = new();
            int count = 0;
            try
            {
                var query = SpecificationEvaluator<T>.GetQuery(DbSet, specification);
                count = await query.CountAsync(cancellationToken);
                result = await query.ToListAsync(cancellationToken);
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