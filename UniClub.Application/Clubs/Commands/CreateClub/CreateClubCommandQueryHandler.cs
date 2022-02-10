using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.Clubs.Commands.CreateClub
{
    public class CreateClubCommandQueryHandler : IRequestHandler<CreateClubCommand, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public CreateClubCommandQueryHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubCommand request, CancellationToken cancellationToken)
        {
            return await _clubRepository.CreateAsync(_mapper.Map<Club>(request), cancellationToken);
        }
    }
}
