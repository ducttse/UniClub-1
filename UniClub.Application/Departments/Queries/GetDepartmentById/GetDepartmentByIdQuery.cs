using MediatR;
using UniClub.Application.Departments.Dtos;

namespace UniClub.Application.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
