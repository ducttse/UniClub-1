﻿using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.ClubRoles.Dtos;
using UniClub.Application.Helpers;
using UniClub.Domain.Common;
using UniClub.Domain.Repositories.Interfaces;

namespace UniClub.Application.ClubRoles.Queries.GetClubRolesWithPagination
{
    public class GetClubRolesWithPaginationQueryHandler : IRequestHandler<GetClubRolesWithPaginationQuery, PaginatedList<ClubRoleDto>>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public GetClubRolesWithPaginationQueryHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubRoleDto>> Handle(GetClubRolesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.OrderBy))
            {
                request.OrderBy = new ClubRoleDto().HasProperty(request.OrderBy);
            }
            var result = await _clubRoleRepository.GetListAsync(cancellationToken, new GetClubRolesWithPaginationSpecification(request));
            return new PaginatedList<ClubRoleDto>(result.Items.Select(e => _mapper.Map<ClubRoleDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
