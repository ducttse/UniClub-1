using MediatR;

namespace UniClub.Application.Universities.Commands.DeleteUniversity
{
    public class DeleteUniversityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteUniversityCommand(int id)
        {
            Id = id;
        }
    }
}
