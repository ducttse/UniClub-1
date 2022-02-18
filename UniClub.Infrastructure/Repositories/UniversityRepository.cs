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
                                        || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                        || e.Website.Contains(searchValue)
                                        || e.UniPhone.Contains(searchValue)
                                        || EF.Functions.Collate(e.UniName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                        || EF.Functions.Collate(e.UniAddress, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                        || EF.Functions.Collate(e.Slogan, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                        || e.EstablishedDate.ToString().Equals(searchValue));
    }
}
