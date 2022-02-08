using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common.Enums;

namespace UniClub.Application.ClubPeriods.Commands.UpdateClubPeriod
{
    public class UpdateClubPeriodCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public ClubPeriodStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
