using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.ClubPeriods.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.ClubPeriods.Queries.GetClubPeriodsWithPagination
{
    public class GetClubPeriodsWithPaginationQueryHandler : IRequestHandler<GetClubPeriodsWithPaginationQuery, PaginatedList<ClubPeriodDto>>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public GetClubPeriodsWithPaginationQueryHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubPeriodDto>> Handle(GetClubPeriodsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _clubPeriodRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new PaginatedList<ClubPeriodDto>(result.Items.Select(e => _mapper.Map<ClubPeriodDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
