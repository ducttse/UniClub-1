using System;
using UniClub.Services.Interfaces;

namespace UniClub.Interfaces
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow.AddHours(7);
    }
}
