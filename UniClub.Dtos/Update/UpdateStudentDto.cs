using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common;

namespace UniClub.Dtos.Update
{
    public class UpdateStudentDto : IRequest<Result>
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? DepId { get; set; }
    }
}
