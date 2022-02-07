using System.Threading;
using System.Threading.Tasks;

namespace UniClub.Domain.Common.Interfaces
{
    public interface ICRUDRepository<T, TKey> where T : AuditableEntity<TKey>
    {
        Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken);
        Task<PaginatedList<T>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<int> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
