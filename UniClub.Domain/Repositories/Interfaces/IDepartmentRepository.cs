using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;

namespace UniClub.Domain.Repositories.Interfaces
{
    public interface IDepartmentRepository : ICRUDRepository<Department, int>
    {
    }
}
