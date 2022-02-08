using MediatR;
using UniClub.Application.Members.Dtos;
using UniClub.Domain.Common;

namespace UniClub.Application.Members.Queries.GetMembersWithPagination
{
    public class GetMembersWithPaginationQuery : IRequest<PaginatedList<MemberDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
