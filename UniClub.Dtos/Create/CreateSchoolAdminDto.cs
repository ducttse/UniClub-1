using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniClub.Dtos.Create
{
    public class CreateSchoolAdminDto : IRequest<string>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [JsonIgnore]
        public string Password { get; set; }
        public IFormFile UploadedImage { get; set; }
        [Required]
        public int UniId { get; set; }
        [JsonIgnore]
        public string ImageUrl { get; set; }
    }
}
