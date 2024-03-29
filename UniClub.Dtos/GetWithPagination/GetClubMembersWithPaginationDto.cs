﻿using MediatR;
using System;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetClubMembersWithPaginationDto : RequestPaginationQuery<MemberRoleProperties?>, IRequest<PaginatedList<MemberRoleDto>>
    {
        private int _clubPeriodId;
        public void SetClubPeriodId(int clubPeriodId) => _clubPeriodId = clubPeriodId;
        public int ClubPeriodId { get => _clubPeriodId; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public override MemberRoleProperties? OrderBy { get; set; }
    }
}
