﻿using AutoMapper;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Dtos.Delete;
using UniClub.Dtos.Response;
using UniClub.Dtos.Update;

namespace UniClub.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region UniversityMapping
            CreateMap<University, UniversityDto>().ReverseMap();
            CreateMap<CreateUniversityDto, University>();
            CreateMap<UpdateUniversityDto, University>();
            CreateMap<DeleteUniversityDto, University>();
            CreateMap<UniversityDto, UpdateUniversityDto>();
            #endregion

            #region ClubMapping
            CreateMap<Club, ClubDto>();
            CreateMap<CreateClubDto, Club>();
            CreateMap<UpdateClubDto, Club>();
            CreateMap<DeleteClubDto, Club>();
            CreateMap<ClubDto, UpdateClubDto>();
            #endregion

            #region ClubPeriodMapping
            CreateMap<ClubPeriod, ClubPeriodDto>().ReverseMap();
            CreateMap<CreateClubPeriodDto, ClubPeriod>();
            CreateMap<UpdateClubPeriodDto, ClubPeriod>();
            CreateMap<DeleteClubPeriodDto, ClubPeriod>();
            CreateMap<ClubPeriodDto, UpdateClubPeriodDto>();
            #endregion

            #region ClubTaskMapping
            CreateMap<ClubTask, ClubTaskDto>().ReverseMap();
            CreateMap<CreateClubTaskDto, ClubTask>();
            CreateMap<UpdateClubTaskDto, ClubTask>();
            CreateMap<DeleteClubTaskDto, ClubTask>();
            CreateMap<ClubTaskDto, UpdateClubTaskDto>();
            #endregion

            #region DepartmentMapping
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();
            CreateMap<DeleteDepartmentDto, Department>();
            CreateMap<DepartmentDto, UpdateDepartmentDto>();
            #endregion

            #region EventMapping
            CreateMap<Event, EventDto>()
                .ForMember(dto => dto.EventByClubs, opt => opt.MapFrom(e => e.EventByClubs));
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
            CreateMap<DeleteEventDto, Event>();
            CreateMap<EventDto, UpdateEventDto>();
            #endregion


            #region PostMapping
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<CreatePostDto, Post>();
            CreateMap<UpdatePostDto, Post>();
            CreateMap<DeletePostDto, Post>();
            #endregion

            #region PostImageMapping
            CreateMap<PostImage, PostImageDto>().ReverseMap();
            CreateMap<CreatePostImageDto, PostImage>();
            CreateMap<UpdatePostImageDto, PostImage>();
            CreateMap<DeletePostImageDto, PostImage>();
            #endregion

            #region Student
            CreateMap<Person, UserDto>()
                .ForMember(dto => dto.DepName, opt => opt.MapFrom(e => e.Dep.DepName));
            CreateMap<CreateUserDto, Person>();
            CreateMap<UpdateUserDto, Person>();
            CreateMap<UserDto, UpdateUserDto>();
            #endregion

            #region ClubMembers
            CreateMap<MemberRole, MemberRoleDto>()
                .ForMember(dto => dto.StudentId, opt => opt.MapFrom(e => e.MemberId))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.Member.Name))
                .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(e => e.Member.DateOfBirth))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(e => e.Member.Email))
                .ForMember(dto => dto.Role, opt => opt.MapFrom(e => e.ClubRoleId))
                .ForMember(dto => dto.ImageUrl, opt => opt.MapFrom(e => e.Member.ImageUrl))
                .ForMember(dto => dto.Gender, opt => opt.MapFrom(e => e.Member.Gender));
            CreateMap<CreateClubMemberDto, MemberRole>()
                .ForMember(e => e.ClubRoleId, opt => opt.MapFrom(dto => dto.Role));
            CreateMap<UpdateClubMemberDto, MemberRole>();
            CreateMap<DeleteClubMemberDto, MemberRole>();
            #endregion

            #region SchoolAdmin
            CreateMap<CreateSchoolAdminDto, Person>();
            #endregion

            #region ClubAdmin
            CreateMap<CreateClubAdminDto, Person>();
            #endregion
        }
    }
}
