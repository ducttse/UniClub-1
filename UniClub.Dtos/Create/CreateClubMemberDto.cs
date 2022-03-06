using MediatR;
using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Create
{
    public class CreateClubMemberDto : IRequest<int>
    {
        public int ClubRoleId { get; set; }
        public MemberRoleStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        private int _clubPeriodId;
        public int GetClubPeriodId() => _clubPeriodId;
        public void SetClubPeriodId(int clubPeriodId) => _clubPeriodId = clubPeriodId;
    }
}
