using MediatR;
using UniClub.Application.Clubs.Dtos;

namespace UniClub.Application.Clubs.Queries.GetClubWithId
{
    public class GetClubByIdQuery : IRequest<ClubDto>
    {
        public int Id { get; set; }
        public GetClubByIdQuery(int id)
        {
            Id = id;
        }
    }
}
