using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Application.Members.Commands.UpdateMember
{
    public class UpdateMemberCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public string StudentId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClubId { get; set; }
    }
}
