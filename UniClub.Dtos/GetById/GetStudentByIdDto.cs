using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetStudentByIdDto : IRequest<StudentDto>
    {
        public string Id { get; }
        public GetStudentByIdDto(string id)
        {
            Id = id;
        }
    }
}
