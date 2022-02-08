using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.ClubRoles.Commands.DeleteClubRole
{
    public class DeleteClubRoleCommandHandler : IRequestHandler<DeleteClubRoleCommand, int>
    {
        private readonly IClubRoleRepository _clubRoleRepository;

        public DeleteClubRoleCommandHandler(IClubRoleRepository clubRoleRepository)
        {
            _clubRoleRepository = clubRoleRepository;
        }

        public async Task<int> Handle(DeleteClubRoleCommand request, CancellationToken cancellationToken)
        {
            return await _clubRoleRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
