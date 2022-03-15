﻿using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Response
{
    public class MemberRoleDto
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public int ClubRoleId { get; set; }
        public string Role { get; set; }
        public MemberRoleStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClubPeriodId { get; set; }
    }
}