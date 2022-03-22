using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniClub.Dtos.Create
{
    public class CreateClubAdminDto : IRequest<string>
    {
        private int _clubId;
        private int _uniId;

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [JsonIgnore]
        [Required]
        public string Password { get; set; }
        public IFormFile UploadedImage { get; set; }
        public string ImageUrl { get; set; }
        public int ClubId { get => _clubId; }
        public void SetClubId(int clubId) => _clubId = clubId;
        public int UniId { get => _uniId; }
        public void SetUniId(int uniId) => _uniId = uniId;
    }
}
