using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Students.Dtos;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.Application.Students.Queries.GetStudentsWithPagination
{
    public class GetStudentsWithPaginationQueryHandler : IRequestHandler<GetStudentsWithPaginationQuery, PaginatedList<StudentDto>>
    {
        private readonly string STUDENT_ROLE = "Student";
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public GetStudentsWithPaginationQueryHandler(UserManager<Person> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<PaginatedList<StudentDto>> Handle(GetStudentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.GetUsersInRoleAsync(STUDENT_ROLE);
            var result = users.Skip((request.PageNumber - 1) * request.PageSize).Select(e => _mapper.Map<StudentDto>(e)).ToList();
            return new PaginatedList<StudentDto>(result, users.Count, request.PageNumber, request.PageSize);
        }
    }
}
