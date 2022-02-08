using MediatR;
using UniClub.Application.Students.Dtos;

namespace UniClub.Application.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public string Id { get; set; }
        public GetStudentByIdQuery(string id)
        {
            Id = id;
        }
    }
}
