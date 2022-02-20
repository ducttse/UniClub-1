using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.ClubPeriods.Dtos;
using UniClub.Application.Helpers;
using UniClub.Domain.Common;
using UniClub.Domain.Repositories.Interfaces;

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
            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                request.OrderBy = new ClubPeriodDto().HasProperty(request.OrderBy);
            }
            var result = await _clubPeriodRepository.GetListAsync(cancellationToken, new GetClubPeriodsWithPaginationSpecification(request));
            return new PaginatedList<ClubPeriodDto>(result.Items.Select(e => _mapper.Map<ClubPeriodDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
