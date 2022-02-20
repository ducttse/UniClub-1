using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Helpers;
using UniClub.Application.Universities.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.Universities.Queries.GetUniversitiesWithPagination
{
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
            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                request.OrderBy = request.HasProperty(request.OrderBy);
            }
            var result = await _universityRepository.GetListAsync(cancellationToken, new GetUniversitiesWithPaginationSpecification(request));
            return new PaginatedList<UniversityDto>(result.Items.Select(e => _mapper.Map<UniversityDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
