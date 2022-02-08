using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
