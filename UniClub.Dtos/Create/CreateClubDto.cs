using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Create
{
    public class CreateClubDto : IRequest<int>
    {
        private int _uniId;
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get => _uniId; }
        public int SetUniId(int uniId) => _uniId = uniId;
        public string AvatarUrl { get; set; }
        public IFormFile UploadedAvatar { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime EstablishedDate { get; set; }
        public string Slogan { get; set; }
    }
}
