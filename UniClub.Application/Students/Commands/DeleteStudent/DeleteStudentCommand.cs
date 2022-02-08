using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;

namespace UniClub.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public string Id { get; set; }
        public DeleteStudentCommand(string id)
        {
            Id = id;
        }
    }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
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
