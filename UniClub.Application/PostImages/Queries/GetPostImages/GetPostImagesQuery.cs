using MediatR;
using System.Collections.Generic;
using UniClub.Application.PostImages.Dtos;

namespace UniClub.Application.PostImages.Queries.GetPostImagesWithPagination
{
    public class GetPostImagesQuery : IRequest<List<PostImageDto>>
    {
    }
}
