using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubPeriods.Commands.UpdateClubPeriod
{
    public class UpdateClubPeriodCommandHandler : IRequestHandler<UpdateClubPeriodCommand, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public UpdateClubPeriodCommandHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubPeriodCommand request, CancellationToken cancellationToken)
        {
            return await _clubPeriodRepository.UpdateAsync(_mapper.Map<ClubPeriod>(request), cancellationToken);
        }
    }
}
