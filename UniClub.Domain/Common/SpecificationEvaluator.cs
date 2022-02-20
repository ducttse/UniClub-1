using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using UniClub.Domain.Common.Interfaces;

namespace UniClub.Domain.Common
{
    public class SpecificationEvaluator<TEntity> where TEntity : class, ISoftDelete
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecification<TEntity> specifications)
        {
            // Do not apply anything if specifications is null
            if (specifications == null)
            {
                return query;
            }

            if (specifications.SoftDeleteFilter)
            {
                query = query.Where(e => e.IsDeleted == false);
            }

            // Modify the IQueryable
            // Apply filter conditions
            foreach (var condition in specifications.FilterCondition)
            {
                query = query.Where(condition);
            }

            // Includes
            query = specifications.Includes
                        .Aggregate(query, (current, include) => current.Include(include));

            // Apply ordering
            if (!string.IsNullOrEmpty(specifications.OrderBy))
            {
                query = specifications.IsAscending ? query.OrderBy($"{specifications.OrderBy}") : query.OrderBy($"{specifications.OrderBy} descending");
            }

            // Apply GroupBy
            if (specifications.GroupBy != null)
            {
                query = query.GroupBy(specifications.GroupBy).SelectMany(x => x);
            }

            if (specifications.IsPagination)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }


            return query;
        }
    }
}
