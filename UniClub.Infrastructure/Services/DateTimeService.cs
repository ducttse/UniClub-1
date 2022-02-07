using System;
using UniClub.Application.Common.Interfaces;

namespace UniClub.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
