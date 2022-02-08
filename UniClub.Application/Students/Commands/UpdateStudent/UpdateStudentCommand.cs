using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Application.Models;

namespace UniClub.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Result>
    {
        [Required]
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? DepId { get; set; }
    }
}
