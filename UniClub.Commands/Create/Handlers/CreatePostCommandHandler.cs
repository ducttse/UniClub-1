using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;
using UniClub.Services.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostDto, int>
    {
        private readonly IPostRepository _postReposiotry;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IUploadService uploadService, IMapper mapper)
        {
            _postReposiotry = postRepository;
            _uploadService = uploadService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePostDto request, CancellationToken cancellationToken)
        {
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
            var entity = _mapper.Map<Post>(request);
            entity.PostImages = postImages;
            return await _postReposiotry.CreateAsync(entity, cancellationToken);
        }
    }
}
