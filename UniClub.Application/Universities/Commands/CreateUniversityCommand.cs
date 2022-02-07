using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Application.Universities.Commands
{
    public class CreateUniversityCommand : IRequest<int>
    {
        public string UniName { get; set; }
        public string UniAddress { get; set; }
        public string UniPhone { get; set; }
        public string LogoUrl { get; set; }
        public string Slogan { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Website { get; set; }
        public string ShortName { get; set; }
    }

    public class CreateUniversityCommandQueryHandler : IRequestHandler<CreateUniversityCommand, int>
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;

        public CreateUniversityCommandQueryHandler(IUniversityRepository universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
        {
            return await _universityRepository.CreateAsync(_mapper.Map<University>(request), cancellationToken);
        }
    }
}
