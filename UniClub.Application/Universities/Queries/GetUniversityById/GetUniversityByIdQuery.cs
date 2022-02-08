using MediatR;
using UniClub.Application.Universities.Dtos;

namespace UniClub.Application.Universities.Queries.GetUniversityById
{
    public class GetUniversityByIdQuery : IRequest<UniversityDto>
    {
        public int Id { get; set; }
        public GetUniversityByIdQuery(int id)
        {
            Id = id;
        }
    }
}
