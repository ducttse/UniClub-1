using MediatR;
using UniClub.Application.Universities.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Universities.Queries.GetUniversitiesWithPagination
{
    public class GetUniversitiesWithPaginationQuery : IRequest<PaginatedList<UniversityDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
