using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteStudentDto : IRequest<int>
    {
        public string Id { get; }
        public DeleteStudentDto(string id)
        {
            Id = id;
        }
    }
}