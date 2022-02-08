using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandQueryHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.CreateAsync(_mapper.Map<Department>(request), cancellationToken);
        }
    }
}
