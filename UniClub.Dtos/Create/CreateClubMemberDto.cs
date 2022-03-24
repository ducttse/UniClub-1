using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Create
{
    public class CreateClubMemberDto : IRequest<int>
    {
        [Required]
        public string MemberId { get; set; }
        public ClubRole Role { get; set; }
        public MemberRoleStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        private int _clubPeriodId;
        private int _clubId;

        public int GetClubPeriodId() => _clubPeriodId;
        public void SetClubPeriodId(int clubPeriodId) => _clubPeriodId = clubPeriodId;
        public int ClubId { get => _clubId; }
        public void SetClubId(int clubId) => _clubId = clubId;
    }
}
