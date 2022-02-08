using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Clubs.Dtos;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Clubs.Queries.GetClubById
{
    public class GetClubByIdQueryHandler : IRequestHandler<GetClubByIdQuery, ClubDto>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public GetClubByIdQueryHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }
        public async Task<ClubDto> Handle(GetClubByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubDto>(await _clubRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
