using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UniClub.Domain.Common;

namespace UniClub.Dtos.Update
{
    public class UpdateUserDto : IRequest<Result>
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public int? DepId { get; set; }
        public IFormFile UploadedImage { get; set; }
        [JsonIgnore]
        public string ImageUrl { get; set; }
    }
}
