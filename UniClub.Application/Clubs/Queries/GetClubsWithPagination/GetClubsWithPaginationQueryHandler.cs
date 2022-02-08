using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Clubs.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Clubs.Queries.GetClubsWithPagination
{
    public class GetClubsWithPaginationQueryHandler : IRequestHandler<GetClubsWithPaginationQuery, PaginatedList<ClubDto>>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public GetClubsWithPaginationQueryHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubDto>> Handle(GetClubsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _clubRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new PaginatedList<ClubDto>(result.Items.Select(e => _mapper.Map<ClubDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
