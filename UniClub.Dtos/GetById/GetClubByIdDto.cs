using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetClubByIdDto : IRequest<ClubDto>
    {
        public int Id { get; }
        public int UniId { get; set; }
        public GetClubByIdDto(int id, int uniId)
        {
            Id = id;
            UniId = uniId;
        }
    }
}
