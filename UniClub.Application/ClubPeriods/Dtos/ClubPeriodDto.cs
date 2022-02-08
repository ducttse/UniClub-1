﻿using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Application.ClubPeriods.Dtos
{
    public class ClubPeriodDto
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public ClubPeriodStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
