using MediatR;
using UniClub.Application.PostImages.Dtos;

namespace UniClub.Application.PostImages.Queries.GetPostImageWithId
{
    public class GetPostImageByIdQuery : IRequest<PostImageDto>
    {
        public int Id { get; set; }
        public GetPostImageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
