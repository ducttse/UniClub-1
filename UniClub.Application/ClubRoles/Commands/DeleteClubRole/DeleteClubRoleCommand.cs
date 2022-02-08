using MediatR;

namespace UniClub.Application.ClubRoles.Commands.DeleteClubRole
{
    public class DeleteClubRoleCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteClubRoleCommand(int id)
        {
            Id = id;
        }
    }
}
