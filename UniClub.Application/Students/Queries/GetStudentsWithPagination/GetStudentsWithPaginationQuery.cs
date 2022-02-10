using MediatR;
using UniClub.Application.Common;
using UniClub.Application.Students.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Students.Queries.GetStudentsWithPagination
{
    public class GetStudentsWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<StudentDto>>
    {
    }
}
