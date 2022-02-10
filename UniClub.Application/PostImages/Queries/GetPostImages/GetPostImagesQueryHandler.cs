using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.PostImages.Dtos;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.PostImages.Queries.GetPostImagesWithPagination
{
    public class GetPostImagesQueryHandler : IRequestHandler<GetPostImagesQuery, List<PostImageDto>>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public GetPostImagesQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<List<PostImageDto>> Handle(GetPostImagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _postImageRepository.GetAllWithoutPaginationAsync(cancellationToken);
            return new List<PostImageDto>(result.Select(e => _mapper.Map<PostImageDto>(e))).ToList();
        }
    }
}
