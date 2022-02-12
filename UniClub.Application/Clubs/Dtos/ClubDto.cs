using System;

namespace UniClub.Application.Clubs.Dtos
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get; set; }
        public string UniName { get; set; }
        public string UniShortName { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int MemberCount { get; set; }
        public string Slogan { get; set; }
    }
}
