using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubPeriods.Commands.CreateClubPeriod
{
    public class CreateClubPeriodCommandQueryHandler : IRequestHandler<CreateClubPeriodCommand, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public CreateClubPeriodCommandQueryHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubPeriodCommand request, CancellationToken cancellationToken)
        {
            return await _clubPeriodRepository.CreateAsync(_mapper.Map<ClubPeriod>(request), cancellationToken);
        }
    }
}
