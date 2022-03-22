using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteClubDto : IRequest<int>
    {
        public int Id { get; }
        public int UniId { get; }
        public DeleteClubDto(int id, int uniId)
        {
            Id = id;
            UniId = uniId;
        }
    }
}
