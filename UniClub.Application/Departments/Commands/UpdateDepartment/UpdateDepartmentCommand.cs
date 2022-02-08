using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int UniId { get; set; }
        public string DepName { get; set; }
        public string ShortName { get; set; }
    }
}
