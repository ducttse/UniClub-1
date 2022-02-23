using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateClubTaskCommandHandler : IRequestHandler<UpdateClubTaskDto, int>
    {
        private readonly IClubTaskRepository _universityRepository;
        private readonly IMapper _mapper;

        public UpdateClubTaskCommandHandler(IClubTaskRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubTaskDto request, CancellationToken cancellationToken)
        {
            return await _universityRepository.UpdateAsync(_mapper.Map<ClubTask>(request), cancellationToken);
        }
    }
}
