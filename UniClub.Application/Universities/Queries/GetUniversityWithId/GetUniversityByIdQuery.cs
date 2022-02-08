using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Universities.Dtos;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Universities.Queries.GetUniversityWithId
{
    public class GetUniversityByIdQuery : IRequest<UniversityDto>
    {
        public int Id { get; set; }
        public GetUniversityByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUniversityByIdQueryHandler : IRequestHandler<GetUniversityByIdQuery, UniversityDto>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public GetUniversityByIdQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }
        public async Task<UniversityDto> Handle(GetUniversityByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UniversityDto>(await _universityRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
