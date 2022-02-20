using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class DepartmentRepository : CRUDRepository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Departments;
        }

        protected override DbSet<Department> DbSet { get; }

    }
}
