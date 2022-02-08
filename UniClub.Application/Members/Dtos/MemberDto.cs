using System;

namespace UniClub.Application.Members.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClubId { get; set; }
    }
}
