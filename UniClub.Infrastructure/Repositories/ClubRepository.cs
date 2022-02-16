using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class ClubRepository : CRUDRepository<Club, int>, IClubRepository
    {
        public ClubRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Clubs;
        }

        protected override DbSet<Club> DbSet { get; }

        public override async Task<Club> GetByIdAsync(int id, CancellationToken cancellationToken, bool isDelete = false)
            => isDelete ? await DbSet.Where(e => e.Id.Equals(id)).Include(e => e.Uni).FirstOrDefaultAsync(cancellationToken)
                        : await DbSet.Where(e => e.Id.Equals(id) && !e.IsDeleted).Include(e => e.Uni).FirstOrDefaultAsync(cancellationToken);

        public override async Task<(List<Club> Items, int Count)> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken, string searchValue = null, string orderBy = null, bool IsAscending = true, bool isDelete = false, DateTime? startDate = null, DateTime? endDate = null)
        {
            List<Club> result = new();
            int count = 0;
            try
            {
                IQueryable<Club> query = null;

                if (!isDelete)
                {
                    query = query == null ? DbSet.Where(e => !e.IsDeleted) : query = query.Where(e => !e.IsDeleted);
                }

                if (!string.IsNullOrWhiteSpace(searchValue))
                {
                    query = Search(DbSet, searchValue);
                }

                if (!string.IsNullOrWhiteSpace(orderBy))
                {
                    query = IsAscending ? query = query.OrderBy(orderBy) : query = query.OrderBy($"{orderBy} descending");
                }

                if (query == null)
                {
                    count = await DbSet.CountAsync(cancellationToken);
                    result = await DbSet.Include(e => e.Uni).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
                }
                else
                {
                    count = await query.CountAsync(cancellationToken);
                    result = await query.Include(e => e.Uni).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return (result, count);
        }

        protected override IQueryable<Club> Search(IQueryable<Club> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                    || e.ClubName.Contains(searchValue)
                                    || e.ShortName.Contains(searchValue)
                                    || e.Description.Contains(searchValue)
                                    || e.ShortDescription.Contains(searchValue)
                                    || e.EstablishedDate.ToString().Contains(searchValue)
                                    || e.Slogan.Contains(searchValue))
            .Include(e => e.Uni)
            .Include(e => e.ClubPeriods.Where(p => p.StartDate <= DateTime.Now.AddDays(-1) && p.EndDate >= DateTime.Now.AddDays(-1)))
            .ThenInclude(e => e.MemberRoles).Select(e => new Club
            {
                Id = e.Id,
                ClubName = e.ClubName,
                ShortName = e.ShortName,
                Description = e.Description,
                ShortDescription = e.ShortDescription,
                Slogan = e.Slogan,
                AvatarUrl = e.AvatarUrl,
                EstablishedDate = e.EstablishedDate,
                UniId = e.Uni.Id,
                MemberCount = e.ClubPeriods.SelectMany(p => p.MemberRoles).Count(),
            });
    }
}
