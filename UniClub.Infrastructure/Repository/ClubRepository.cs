using Microsoft.EntityFrameworkCore;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class ClubRepository : CRUDRepository<Club, int>, IClubRepository
    {
        public ClubRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Clubs;
        }

        protected override DbSet<Club> DbSet { get; }
    }
}
