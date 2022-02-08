using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Departments.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Departments.Queries.GetDepartmentsWithPagination
{
    public class GetDepartmentsWithPaginationQuery : IRequest<PaginatedList<DepartmentDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

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
            var result = await _departmentRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new PaginatedList<DepartmentDto>(result.Items.Select(e => _mapper.Map<DepartmentDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
