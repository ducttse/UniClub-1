using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Create
{
    public class CreateUserDto : IRequest<string>
    {
        private Role _role;
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? DepId { get; set; }
        public string Password { get; set; }

        public void SetRole(Role role) => _role = role;
        public Role GetRole() => _role;
    }
}
