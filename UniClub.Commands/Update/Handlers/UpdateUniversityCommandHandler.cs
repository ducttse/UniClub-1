using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Update.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityDto, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public UpdateUniversityCommandHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateUniversityDto request, CancellationToken cancellationToken)
        {
            var entity = await _universityRepository.GetByIdAsync(cancellationToken, new UpdateUniversityCommandSpecification(request));
            return await _universityRepository.UpdateAsync(entity, _mapper.Map<University>(request), cancellationToken);
        }
    }
}
