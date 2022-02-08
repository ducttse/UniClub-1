using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Members.Commands.DeleteMember
{
    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, int>
    {
        private readonly IMemberRepository _memberRepository;

        public DeleteMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<int> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            return await _memberRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
