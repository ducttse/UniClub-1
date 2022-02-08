﻿using System;

namespace UniClub.Application.ClubRoles.Dtos
{
    public class ClubRoleDto
    {
        public int Id { get; set; }
        public string UniName { get; set; }
        public string UniAddress { get; set; }
        public string UniPhone { get; set; }
        public string LogoUrl { get; set; }
        public string Slogan { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Website { get; set; }
        public string ShortName { get; set; }
    }
}