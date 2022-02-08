using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.ClubTasks.Commands.UpdateClubTask
{
    public class UpdateClubTaskCommandHandler : IRequestHandler<UpdateClubTaskCommand, int>
    {
        private readonly IClubTaskRepository _universityRepository;
        private readonly IMapper _mapper;

        public UpdateClubTaskCommandHandler(IClubTaskRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubTaskCommand request, CancellationToken cancellationToken)
        {
            return await _universityRepository.UpdateAsync(_mapper.Map<ClubTask>(request), cancellationToken);
        }
    }
}
