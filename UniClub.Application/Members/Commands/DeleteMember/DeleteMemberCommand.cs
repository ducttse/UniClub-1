using MediatR;

namespace UniClub.Application.Members.Commands.DeleteMember
{
    public class DeleteMemberCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteMemberCommand(int id)
        {
            Id = id;
        }
    }
}
