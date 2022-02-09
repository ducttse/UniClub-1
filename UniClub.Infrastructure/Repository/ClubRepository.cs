using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public override async Task<Club> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await DbSet.Where(e => e.Id.Equals(id)).Include(e => e.Uni).FirstOrDefaultAsync(cancellationToken);

        public async Task<(List<Club> Items, int Count)> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            List<Club> result = new();
            int count = 0;
            try
            {
                count = await DbSet.CountAsync(cancellationToken);
                result = await DbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).Include(e => e.Uni).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            return (result, count);
        }
    }
}
