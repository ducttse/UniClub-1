using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.PostImages.Commands.UpdatePostImage
{
    public class UpdatePostImageCommandHandler : IRequestHandler<UpdatePostImageCommand, int>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public UpdatePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePostImageCommand request, CancellationToken cancellationToken)
        {
            return await _postImageRepository.UpdateAsync(_mapper.Map<PostImage>(request), cancellationToken);
        }
    }
}
