using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentDto, int>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<int> Handle(DeleteDepartmentDto request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.DeleteAsync(request.Id, cancellationToken);
        }
    }
}
