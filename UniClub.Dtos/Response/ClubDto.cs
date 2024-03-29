﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Response
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Email { get; set; }
        public int UniId { get; set; }
        public string AvatarUrl { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]

        public DateTime EstablishedDate { get; set; }
        public int MemberCount { get; set; }
        public string Slogan { get; set; }
        public bool IsDeleted { get; set; }
    }
}
