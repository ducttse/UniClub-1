using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetStudentByIdDto : IRequest<UserDto>
    {
        public string Id { get; }
        public int UniId { get; }
        public GetStudentByIdDto(string id, int uniId)
        {
            Id = id;
            UniId = uniId;
        }
    }
}
