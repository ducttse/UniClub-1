using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Helpers;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetUniversitiesWithPaginationQueryHandler : IRequestHandler<GetUniversitiesWithPaginationDto, PaginatedList<UniversityDto>>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetUniversitiesWithPaginationQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<UniversityDto>> Handle(GetUniversitiesWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = await _universityRepository.GetListAsync(cancellationToken, new GetUniversitiesWithPaginationSpecification(request));
            return new PaginatedList<UniversityDto>(result.Items.Select(e => _mapper.Map<UniversityDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
