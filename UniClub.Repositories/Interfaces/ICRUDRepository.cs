using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Specifications.Interfaces;

namespace UniClub.Repositories.Interfaces
{
    public interface ICRUDRepository<T, TKey> where T : AuditableEntity<TKey>
    {
        Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken, ISpecification<T> specification = null);
        Task<(List<T> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<T> specification);
        Task<int> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<int> DeleteAsync(TKey id, CancellationToken cancellationToken);
        Task<int> HardDeleteAsync(TKey id, CancellationToken cancellationToken);
    }
}
