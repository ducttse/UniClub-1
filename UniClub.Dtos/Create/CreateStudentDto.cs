using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniClub.Dtos.Create
{
    public class CreateStudentDto : IRequest<string>
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
        public int UniId { get; set; }
        [Required]
        public int DepId { get; set; }
        [JsonIgnore]
        public string ImageUrl { get; set; }
    }
}
