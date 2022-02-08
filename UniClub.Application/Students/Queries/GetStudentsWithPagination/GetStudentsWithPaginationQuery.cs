using MediatR;
using UniClub.Application.Students.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Students.Queries.GetStudentsWithPagination
{
    public class GetStudentsWithPaginationQuery : IRequest<PaginatedList<StudentDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
