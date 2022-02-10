using MediatR;
using UniClub.Application.Common;
using UniClub.Application.Universities.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Universities.Queries.GetUniversitiesWithPagination
{
    public class GetUniversitiesWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<UniversityDto>>
    {
    }
}
