using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.PostImages.Queries.GetPostImages
{
    public class GetPostImagesSpecification : BaseSpecification<PostImage>
    {
        public GetPostImagesSpecification(GetPostImagesQuery query)
        {
            NotApplyPagination();
        }
    }
}
