using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubCommandHandler : IRequestHandler<CreateClubDto, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public CreateClubCommandHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubDto request, CancellationToken cancellationToken)
        {
            return await _clubRepository.CreateAsync(_mapper.Map<Club>(request), cancellationToken);
        }
    }
}
