using MediatR;
using UniClub.Application.Common;
using UniClub.Application.Members.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Members.Queries.GetMembersWithPagination
{
    public class GetMembersWithPaginationQuery : RequestPaginationQuery, IRequest<PaginatedList<MemberDto>>
    {
    }
}
