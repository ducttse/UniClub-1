using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.ClubTasks.Dtos;
using UniClub.Application.Helpers;
using UniClub.Domain.Common;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubTasks.Queries.GetClubTasksWithPagination
{
    public class GetClubTasksWithPaginationQueryHandler : IRequestHandler<GetClubTasksWithPaginationQuery, PaginatedList<ClubTaskDto>>
    {
        private readonly IClubTaskRepository _clubTaskRepository;
        private readonly IMapper _mapper;

        public GetClubTasksWithPaginationQueryHandler(IClubTaskRepository clubTaskRepository, IMapper mapper)
        {
            _clubTaskRepository = clubTaskRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubTaskDto>> Handle(GetClubTasksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                request.OrderBy = new ClubTaskDto().HasProperty(request.OrderBy);
            }
            var result = await _clubTaskRepository.GetListAsync(request.PageNumber, request.PageSize, cancellationToken, request.SearchValue, request.OrderBy, request.IsAscending, false, request.StartTime, request.EndTime);
            return new PaginatedList<ClubTaskDto>(result.Items.Select(e => _mapper.Map<ClubTaskDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
