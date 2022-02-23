using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common.Interfaces;
using UniClub.Dtos.Delete;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentDto, int>
    {
        private readonly IApplicationDbContext _context;
        public DeleteStudentCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<int> Handle(DeleteStudentDto request, CancellationToken cancellationToken)
        {

            var student = await _context.People.FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);
            try
            {
                if (student != null)
                {
                    _context.People.Remove(student);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("Object has not existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
