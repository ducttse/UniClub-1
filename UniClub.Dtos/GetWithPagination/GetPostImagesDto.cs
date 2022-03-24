using MediatR;
using System.Collections.Generic;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetPostImagesDto : IRequest<List<PostImageDto>>
    {
        public int PostId { get; }
        public GetPostImagesDto(int postId)
        {
            PostId = postId;
        }
    }
}
