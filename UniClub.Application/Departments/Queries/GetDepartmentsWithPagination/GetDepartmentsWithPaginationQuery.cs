using MediatR;
using UniClub.Application.Common;
using UniClub.Application.Departments.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Departments.Queries.GetDepartmentsWithPagination
{
    public class GetDepartmentsWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<DepartmentDto>>
    {
    }
}
