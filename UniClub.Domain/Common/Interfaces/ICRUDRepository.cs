using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UniClub.Domain.Common.Interfaces
{
    public interface ICRUDRepository<T, TKey> where T : AuditableEntity<TKey>
    {
        Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken, bool isDelete = false);
        Task<List<T>> GetAllWithoutPaginationAsync(CancellationToken cancellationToken);
        Task<(List<T> Items, int Count)> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string searchValue = null, string orderBy = null, bool IsAscending = true, bool isDelete = false, DateTime? startDate = null, DateTime? endDate = null);
        Task<int> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<int> DeleteAsync(TKey id, CancellationToken cancellationToken);
        Task<int> HardDeleteAsync(TKey id, CancellationToken cancellationToken);
    }
}
