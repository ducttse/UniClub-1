using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Universities.Queries.GetUniversityWithId
{
    public class GetUniversityByIdQuery : IRequest<University>
    {
        public int Id { get; set; }
        public GetUniversityByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUniversityByIdQueryHandler : IRequestHandler<GetUniversityByIdQuery, University>
    {
        private readonly IUniversityRepository _universityRepository;

        public GetUniversityByIdQueryHandler(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }
        public Task<University> Handle(GetUniversityByIdQuery request, CancellationToken cancellationToken)
        {
            return _universityRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
