using MediatR;

namespace UniClub.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
