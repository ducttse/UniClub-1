using MediatR;
using UniClub.Application.ClubPeriods.Dtos;

namespace UniClub.Application.ClubPeriods.Queries.GetClubPeriodWithId
{
    public class GetClubPeriodByIdQuery : IRequest<ClubPeriodDto>
    {
        public int Id { get; set; }
        public GetClubPeriodByIdQuery(int id)
        {
            Id = id;
        }
    }
}
