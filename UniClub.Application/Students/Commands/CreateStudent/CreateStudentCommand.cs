using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<string>
    {
        [Required]
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int? DepId { get; set; }
        public string Password { get; set; }
    }
}
