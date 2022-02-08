using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.ClubPeriods.Dtos;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.ClubPeriods.Queries.GetClubPeriodWithId
{
    public class GetClubPeriodByIdQueryHandler : IRequestHandler<GetClubPeriodByIdQuery, ClubPeriodDto>
    {
        private readonly IClubPeriodRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetClubPeriodByIdQueryHandler(IClubPeriodRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }
        public async Task<ClubPeriodDto> Handle(GetClubPeriodByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubPeriodDto>(await _universityRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
