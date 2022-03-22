using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetDepartmentByIdDto : IRequest<DepartmentDto>
    {
        public int Id { get; }
        public int UniId { get; }
        public GetDepartmentByIdDto(int id, int uniId)
        {
            Id = id;
            UniId = uniId;
        }
    }
}
