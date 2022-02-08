using MediatR;
using UniClub.Application.Members.Dtos;

namespace UniClub.Application.Members.Queries.GetMemberById
{
    public class GetMemberByIdQuery : IRequest<MemberDto>
    {
        public int Id { get; set; }
        public GetMemberByIdQuery(int id)
        {
            Id = id;
        }
    }
}
