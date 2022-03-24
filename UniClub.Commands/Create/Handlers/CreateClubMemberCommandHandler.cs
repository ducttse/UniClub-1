using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Create.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubMemberCommandHandler : IRequestHandler<CreateClubMemberDto, int>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public CreateClubMemberCommandHandler(IMemberRoleRepository memberRoleRepository, IClubPeriodRepository clubPeriodRepository, UserManager<Person> userManager, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _clubPeriodRepository = clubPeriodRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubMemberDto request, CancellationToken cancellationToken)
        {
            var result = await _userManager.FindByIdAsync(request.MemberId);
            if (result == null)
            {
                throw new Exception("No student found");
            }

            var clubPeriod = await _clubPeriodRepository.GetByIdAsync(cancellationToken, new GetClubPeriodCommandSpecification(request.GetClubPeriodId()));
            if (clubPeriod == null)
            {
                throw new Exception("This club period is not available to editable");
            }

            var claim = new Claim("club", $"{request.ClubId}-{request.Role}");
            await _userManager.AddClaimAsync(result, claim);
            return await _memberRoleRepository.CreateAsync(_mapper.Map<MemberRole>(request), cancellationToken);
        }
    }
}
