using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.PostImages.Dtos;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.PostImages.Queries.GetPostImageWithId
{
    public class GetPostImageByIdQueryHandler : IRequestHandler<GetPostImageByIdQuery, PostImageDto>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public GetPostImageByIdQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }
        public async Task<PostImageDto> Handle(GetPostImageByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PostImageDto>(await _postImageRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
