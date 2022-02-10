using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Departments.Dtos;
using UniClub.Application.Helpers;
using UniClub.Domain.Common;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.Departments.Queries.GetDepartmentsWithPagination
{
    public class GetDepartmentsWithPaginationQueryHandler : IRequestHandler<GetDepartmentsWithPaginationQuery, PaginatedList<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentsWithPaginationQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<DepartmentDto>> Handle(GetDepartmentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                request.OrderBy = new DepartmentDto().HasProperty(request.OrderBy);
            }
            var result = await _departmentRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken, request.SearchValue, request.OrderBy, request.IsAscending);
            return new PaginatedList<DepartmentDto>(result.Items.Select(e => _mapper.Map<DepartmentDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
