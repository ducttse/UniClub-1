using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Students.Dtos;
using UniClub.Domain.Entities;

namespace UniClub.Application.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(UserManager<Person> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<StudentDto>(await _userManager.FindByIdAsync(request.Id));
        }
    }
}
