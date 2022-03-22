using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetClubMemberByIdDto : IRequest<MemberRoleDto>
    {
        public string MemberId { get; set; }
        public GetClubMemberByIdDto(string memberId)
        {
            MemberId = memberId;
        }

        private int _clubPeriodId;
        public int GetClubPeriodId() => _clubPeriodId;
        public void SetClubPeriodId(int clubPeriodId) => _clubPeriodId = clubPeriodId;
    }
}
