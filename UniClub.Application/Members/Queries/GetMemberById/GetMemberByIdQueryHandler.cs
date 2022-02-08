using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Members.Dtos;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Members.Queries.GetMemberById
{
    public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, MemberDto>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetMemberByIdQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        public async Task<MemberDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<MemberDto>(await _memberRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
