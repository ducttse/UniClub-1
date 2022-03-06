using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common.Exceptions;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;
using UniClub.Specifications;
using UniClub.Specifications.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class MemberRoleRepository : IMemberRoleRepository
    {
        private readonly IApplicationDbContext _context;

        public MemberRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<MemberRole> GetByIdAsync(int clubPeriodId, string memberId, CancellationToken cancellationToken, ISpecification<MemberRole> specification = null)
       => await SpecificationEvaluator<MemberRole>.GetQuery(_context.MemberRoles.Where(e => e.ClubPeriodId == clubPeriodId && e.MemberId.Equals(memberId))
           .AsQueryable(), specification).FirstOrDefaultAsync();

        public async Task<(List<MemberRole> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<MemberRole> specification = null)
        {
            List<MemberRole> result = new();
            int count = 0;
            try
            {
                var query = SpecificationEvaluator<MemberRole>.GetQuery(_context.MemberRoles, specification);
                count = await query.CountAsync(cancellationToken);
                if (specification.IsPagination)
                {
                    result = await query.Skip(specification.Skip).Take(specification.Take).ToListAsync(cancellationToken);
                }
                else
                {
                    result = await query.ToListAsync(cancellationToken);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return (result, count);
        }

        public virtual async Task<int> CreateAsync(MemberRole entity, CancellationToken cancellationToken)
        {
            var e = await GetByIdAsync(entity.ClubPeriodId, entity.MemberId, cancellationToken);
            try
            {
                if (e == null)
                {
                    _context.MemberRoles.Add(entity);
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

        public async Task<int> UpdateAsync(MemberRole entity, CancellationToken cancellationToken)
        {
            MemberRole inDatabase = await GetByIdAsync(entity.ClubPeriodId, entity.MemberId, cancellationToken);
            try
            {
                if (inDatabase != null)
                {
                    UpdateEntityWithInDatabase(inDatabase, entity);
                    _context.Entry(inDatabase).Property(e => e.MemberId).IsModified = false;
                    _context.Entry(inDatabase).Property(e => e.ClubPeriodId).IsModified = false;
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

        public async Task<int> DeleteAsync(MemberRole entity, CancellationToken cancellationToken)
        {
            MemberRole e = await GetByIdAsync(entity.ClubPeriodId, entity.MemberId, cancellationToken);
            try
            {
                if (entity != null)
                {
                    _context.MemberRoles.Remove(entity);
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

        private void UpdateEntityWithInDatabase(MemberRole inDatabase, MemberRole entity)
        {
            foreach (var inDatabaseProperty in inDatabase.GetType().GetProperties())
            {
                if (!inDatabaseProperty.Name.Contains("MemberId") || !inDatabaseProperty.Name.Contains("ClubPeriodId"))
                {
                    var entityValue = entity.GetType().GetProperty(inDatabaseProperty.Name).GetValue(entity);
                    {
                        if (entityValue != null && entityValue != default)
                        {
                            entity.GetType().GetProperty(inDatabaseProperty.Name).SetValue(inDatabase, entityValue);
                        }
                    }
                }
            }
        }
    }
}
