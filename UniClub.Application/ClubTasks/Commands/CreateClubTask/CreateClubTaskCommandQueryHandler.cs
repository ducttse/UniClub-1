using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.ClubTasks.Commands.CreateClubTask
{
    public class CreateClubTaskCommandQueryHandler : IRequestHandler<CreateClubTaskCommand, int>
    {
        private readonly IClubTaskRepository _universityRepository;
        private readonly IMapper _mapper;

        public CreateClubTaskCommandQueryHandler(IClubTaskRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubTaskCommand request, CancellationToken cancellationToken)
        {
            return await _universityRepository.CreateAsync(_mapper.Map<ClubTask>(request), cancellationToken);
        }
    }
}
