using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.ClubTasks.Dtos;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.ClubTasks.Queries.GetClubTaskWithId
{
    public class GetClubTaskByIdQueryHandler : IRequestHandler<GetClubTaskByIdQuery, ClubTaskDto>
    {
        private readonly IClubTaskRepository _clubTaskRepository;
        private readonly IMapper _mapper;

        public GetClubTaskByIdQueryHandler(IClubTaskRepository clubTaskRepository, IMapper mapper)
        {
            _clubTaskRepository = clubTaskRepository;
            _mapper = mapper;
        }
        public async Task<ClubTaskDto> Handle(GetClubTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClubTaskDto>(await _clubTaskRepository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
