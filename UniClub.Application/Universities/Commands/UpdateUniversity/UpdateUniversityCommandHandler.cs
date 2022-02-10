using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.Universities.Commands.UpdateUniversity
{
    public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityCommand, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public UpdateUniversityCommandHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
        {
            return await _universityRepository.UpdateAsync(_mapper.Map<University>(request), cancellationToken);
        }
    }
}
