using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;

namespace UniClub.Queries.GetById.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdDto, StudentDto>
    {
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(UserManager<Person> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<StudentDto> Handle(GetStudentByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<StudentDto>(await _userManager.FindByIdAsync(request.Id));
        }
    }
}
