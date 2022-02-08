using MediatR;
using UniClub.Application.Departments.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Departments.Queries.GetDepartmentsWithPagination
{
    public class GetDepartmentsWithPaginationQuery : IRequest<PaginatedList<DepartmentDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
