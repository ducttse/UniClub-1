﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UniClub.Application.Common;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Infrastructure.Repositories
{
    public class EventRepository : CRUDRepository<Event, int>, IEventRepository
    {
        public EventRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Events;
        }

        protected override DbSet<Event> DbSet { get; }

        protected override IQueryable<Event> Search(IQueryable<Event> query, string searchValue)
            => query.Where(e => e.Id.ToString().Equals(searchValue)
                                    || e.EventName.Contains(searchValue)
                                    || e.Location.Equals(searchValue)
                                    || e.Point.ToString().Equals(searchValue)
                                    || e.MaxParticipants.ToString().Equals(searchValue)
                                    || e.Description.ToString().Contains(searchValue)
                                    || e.Status.ToString().Equals(searchValue));

        protected override IQueryable<Event> InTime(IQueryable<Event> query, DateTime? startDate, DateTime? endDate)
        {
            if (startDate != null && endDate != null)
            {
                return query.Where(e => startDate <= e.StartDate && e.EndDate <= endDate);
            }

            if (startDate != null)
            {
                return query.Where(e => startDate <= e.StartDate);
            }
            if (endDate != null)
            {
                return query.Where(e => e.EndDate <= endDate);
            }
            return query;
        }
    }
}
