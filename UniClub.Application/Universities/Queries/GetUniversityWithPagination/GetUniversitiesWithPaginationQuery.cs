using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Universities.Queries.GetUniversityWithPagination
{
    public class GetUniversitiesWithPaginationQuery : IRequest<PaginatedList<University>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetUniversitiesWithPaginationQueryHandler : IRequestHandler<GetUniversitiesWithPaginationQuery, PaginatedList<University>>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetUniversitiesWithPaginationQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<University>> Handle(GetUniversitiesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _universityRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
