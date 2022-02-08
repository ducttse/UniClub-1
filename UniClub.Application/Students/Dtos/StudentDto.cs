using System;

namespace UniClub.Application.Students.Dtos
{
    public class StudentDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? DepId { get; set; }
    }
}
