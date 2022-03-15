using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Interfaces;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetStudentsWithPaginationQueryHandler(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;

        }

        public async Task<PaginatedList<StudentDto>> Handle(GetStudentsWithPaginationDto request, CancellationToken cancellationToken)
        {
            var query = _context.People;
            var users = await _userManager.GetUsersInRoleAsync(STUDENT_ROLE);

            var students = await SpecificationEvaluator<Person>.GetQuery(query.AsQueryable(), new GetStudentsWithPaginationSpecification(request)).ToListAsync();

            var joinResult = (from student in students
                              join user in users on student.Id equals user.Id
                              select student).ToList();

            var result = joinResult.Select(e => _mapper.Map<StudentDto>(e)).ToList();
            return new PaginatedList<StudentDto>(result, students.Count(), request.PageNumber, request.PageSize);
        }
    }
}
