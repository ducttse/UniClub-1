using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int UniId { get; set; }
        public string DepName { get; set; }
        public string ShortName { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.UpdateAsync(_mapper.Map<Department>(request), cancellationToken);
        }
    }
}
