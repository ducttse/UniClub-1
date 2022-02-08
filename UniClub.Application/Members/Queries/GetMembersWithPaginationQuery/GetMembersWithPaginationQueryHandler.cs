using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Members.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Members.Queries.GetMembersWithPagination
{
    public class GetMembersWithPaginationQueryHandler : IRequestHandler<GetMembersWithPaginationQuery, PaginatedList<MemberDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetMembersWithPaginationQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<MemberDto>> Handle(GetMembersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _memberRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new PaginatedList<MemberDto>(result.Items.Select(e => _mapper.Map<MemberDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
