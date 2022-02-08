using MediatR;
using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Application.ClubTasks.Commands.CreateClubTask
{
    public class CreateClubTaskCommand : IRequest<int>
    {
        public int EventId { get; set; }
        public ClubTaskStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaskName { get; set; }
    }
}
