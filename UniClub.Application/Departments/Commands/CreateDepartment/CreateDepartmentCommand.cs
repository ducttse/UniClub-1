using MediatR;

namespace UniClub.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public int UniId { get; set; }
        public string DepName { get; set; }
        public string ShortName { get; set; }
    }
}
