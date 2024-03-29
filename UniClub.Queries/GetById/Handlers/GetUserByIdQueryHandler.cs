﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Queries.GetById.Specifications;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdDto, UserDto>
    {
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(UserManager<Person> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdDto request, CancellationToken cancellationToken)
        {
            Person user = await SpecificationEvaluator<Person>.GetQuery(_userManager.Users, new GetUserByIdQuerySpecification(request)).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}
