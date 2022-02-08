using MediatR;
using System;

namespace UniClub.Application.Clubs.Commands.CreateClub
{
    public class CreateClubCommand : IRequest<int>
    {
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Slogan { get; set; }
    }
}
