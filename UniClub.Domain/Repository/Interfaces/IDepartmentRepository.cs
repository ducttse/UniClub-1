using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;

namespace UniClub.Domain.Repository.Interfaces
{
    public interface IDepartmentRepository : ICRUDRepository<Department, int>
    {
    }
}
