using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using UniClub.Application.Universities.Commands;
using UniClub.Application.Universities.Dtos;
using UniClub.Domain.Entities;

namespace UniClub.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region UniversityMapping
            CreateMap<University, UniversityDto>().ReverseMap();
            CreateMap<CreateUniversityCommand, University>();
            CreateMap<UpdateUniversityCommand, University>();
            CreateMap<DeleteUniversityCommand, University>(); 
            #endregion


        }
    }
}
