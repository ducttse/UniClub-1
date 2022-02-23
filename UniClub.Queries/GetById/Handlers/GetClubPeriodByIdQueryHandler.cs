using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetById.Handlers
{
    public class GetClubPeriodByIdQueryHandler : IRequestHandler<GetClubPeriodByIdDto, ClubPeriodDto>
    {
        private readonly IClubPeriodRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetClubPeriodByIdQueryHandler(IClubPeriodRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }
        public async Task<ClubPeriodDto> Handle(GetClubPeriodByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubPeriodDto>(await _universityRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
