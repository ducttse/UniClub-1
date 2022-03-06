using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteClubMemberCommandHandler : IRequestHandler<DeleteClubMemberDto, int>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly IMapper _mapper;

        public DeleteClubMemberCommandHandler(IMemberRoleRepository memberRoleRepository, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteClubMemberDto request, CancellationToken cancellationToken)
        {
            return await _memberRoleRepository.DeleteAsync(_mapper.Map<MemberRole>(request), cancellationToken);
        }
    }
}
