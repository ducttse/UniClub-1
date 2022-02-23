using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityDto, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public CreateUniversityCommandHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUniversityDto request, CancellationToken cancellationToken)
        {
            return await _universityRepository.CreateAsync(_mapper.Map<University>(request), cancellationToken);
        }
    }
}
