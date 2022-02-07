using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class UniversityRepository : CRUDRepository<University, int>, IUniversityRepository
    {
        public UniversityRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Universities;
        }

        protected override DbSet<University> DbSet { get; }
    }
}
