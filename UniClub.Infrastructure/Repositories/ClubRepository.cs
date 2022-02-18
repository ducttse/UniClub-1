﻿using Microsoft.EntityFrameworkCore;
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
            => isDelete ? await SelectProperty(DbSet.Where(e => e.Id.Equals(id))).FirstOrDefaultAsync(cancellationToken)
                        : await SelectProperty(DbSet.Where(e => e.Id.Equals(id) && !e.IsDeleted)).FirstOrDefaultAsync(cancellationToken);

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
                    result = await DbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
                }
                else
                {
                    count = await query.CountAsync(cancellationToken);
                    result = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
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
                                    || EF.Functions.Collate(e.ClubName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                    || EF.Functions.Collate(e.ShortName, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                    || EF.Functions.Collate(e.Description, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                    || EF.Functions.Collate(e.ShortDescription, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue)
                                    || e.EstablishedDate.ToString().Contains(searchValue)
                                    || EF.Functions.Collate(e.Slogan, "SQL_Latin1_General_CP1_CI_AI").Contains(searchValue))
            .Include(e => e.Uni)
            .Include(e => e.ClubPeriods.Where(p => p.StartDate <= DateTime.Now.AddDays(-1) && p.EndDate >= DateTime.Now.AddDays(-1)));

        protected override IQueryable<Club> SelectProperty(IQueryable<Club> query) =>
            query
            .Include(e => e.ClubPeriods.Where(p => p.StartDate <= DateTime.Now.AddDays(-15) && p.EndDate >= DateTime.Now.AddDays(-15)))
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
                UniId = e.UniId,
                MemberCount = e.ClubPeriods.SelectMany(p => p.MemberRoles).Count(),
            });
    }
}
