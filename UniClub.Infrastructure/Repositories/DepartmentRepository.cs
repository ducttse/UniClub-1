using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        protected override IQueryable<Department> Search(IQueryable<Department> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                    || e.UniId.ToString().Equals(searchValue)
                                    || EF.Functions.Collate(e.DepName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                    || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue));
    }
}
