using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentDto, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateDepartmentDto request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.UpdateAsync(_mapper.Map<Department>(request), cancellationToken);
        }
    }
}
