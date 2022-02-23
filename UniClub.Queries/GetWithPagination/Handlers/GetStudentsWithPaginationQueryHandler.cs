using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetStudentsWithPaginationQueryHandler : IRequestHandler<GetStudentsWithPaginationDto, PaginatedList<StudentDto>>
    {
        private readonly string STUDENT_ROLE = "Student";
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public GetStudentsWithPaginationQueryHandler(UserManager<Person> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<PaginatedList<StudentDto>> Handle(GetStudentsWithPaginationDto request, CancellationToken cancellationToken)
        {

            var users = await _userManager.GetUsersInRoleAsync(STUDENT_ROLE);
            var result = SpecificationEvaluator<Person>.GetQuery(users.AsQueryable(), new GetStudentsWithPaginationSpecification(request)).Select(e => _mapper.Map<StudentDto>(e)).ToList();
            return new PaginatedList<StudentDto>(result, users.Count, request.PageNumber, request.PageSize);
        }
    }
}
