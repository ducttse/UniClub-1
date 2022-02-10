using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.Clubs.Commands.UpdateClub
{
    public class UpdateClubCommandHandler : IRequestHandler<UpdateClubCommand, int>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public UpdateClubCommandHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubCommand request, CancellationToken cancellationToken)
        {
            return await _clubRepository.UpdateAsync(_mapper.Map<Club>(request), cancellationToken);
        }
    }
}
