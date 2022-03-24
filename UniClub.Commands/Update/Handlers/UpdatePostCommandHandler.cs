using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Update.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;
using UniClub.Services.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostDto, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUploadService _uploadService;
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository PostRepository, IUploadService uploadService, IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postRepository = PostRepository;
            _uploadService = uploadService;
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePostDto request, CancellationToken cancellationToken)
        {
            var entity = await _postRepository.GetByIdAsync(cancellationToken, new UpdatePostCommandSpecification(request));
            foreach (var postImage in entity.PostImages)
            {
                await _postImageRepository.HardDeleteAsync(postImage, cancellationToken);
            }
            var postImages = new List<PostImage>();
            if (request.Images != null)
            {
                var tasks = new List<Task>();
                foreach (var image in request.Images)
                {
                    tasks.Add(_uploadService.Upload(image, "post-images"));
                }
                foreach (var task in tasks)
                {
                    var result = ((Task<string>)task).Result;
                    postImages.Add(new PostImage { ImageUrl = result });
                }
            }

            entity.PostImages = postImages;
            return await _postRepository.UpdateAsync(entity, _mapper.Map<Post>(request), cancellationToken);
        }
    }
}
