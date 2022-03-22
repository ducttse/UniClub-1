using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Update
{
    public class UpdateClubDto : IRequest<int>
    {
        private int _uniId;
        [Required]
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get => _uniId; }
        public IFormFile UploadedAvatar { get; set; }
        public string AvatarUrl { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime EstablishedDate { get; set; }
        public string Slogan { get; set; }

        public void SetUniId(int uniId) => _uniId = uniId;
    }
}
