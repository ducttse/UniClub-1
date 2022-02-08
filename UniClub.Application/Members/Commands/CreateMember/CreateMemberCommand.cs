using MediatR;
using System;

namespace UniClub.Application.Members.Commands.CreateMember
{
    public class CreateMemberCommand : IRequest<int>
    {
        public string StudentId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClubId { get; set; }
    }
}
