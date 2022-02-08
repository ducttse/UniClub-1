using MediatR;
using UniClub.Application.Events.Dtos;

namespace UniClub.Application.Events.Queries.GetEventById
{
    public class GetEventByIdQuery : IRequest<EventDto>
    {
        public int Id { get; set; }
        public GetEventByIdQuery(int id)
        {
            Id = id;
        }
    }
}
