using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class UniversityRepository : CRUDRepository<University, int>, IUniversityRepository
    {
        public UniversityRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Universities;
        }

        protected override DbSet<University> DbSet { get; }

        protected override IQueryable<University> Search(IQueryable<University> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                        || e.ShortName.Contains(searchValue)
                                        || e.Website.Contains(searchValue)
                                        || e.UniPhone.Contains(searchValue)
                                        || e.UniName.Contains(searchValue)
                                        || e.UniAddress.Contains(searchValue)
                                        || e.Slogan.Contains(searchValue)
                                        || e.EstablishedDate.ToString().Equals(searchValue));
    }
}
