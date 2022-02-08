using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Universities.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Universities.Queries.GetUniversitiesWithPagination
{
    public class GetUniversitiesWithPaginationQuery : IRequest<PaginatedList<UniversityDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetUniversitiesWithPaginationQueryHandler : IRequestHandler<GetUniversitiesWithPaginationQuery, PaginatedList<UniversityDto>>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetUniversitiesWithPaginationQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<UniversityDto>> Handle(GetUniversitiesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _universityRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new PaginatedList<UniversityDto>(result.Items.Select(e => _mapper.Map<UniversityDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
