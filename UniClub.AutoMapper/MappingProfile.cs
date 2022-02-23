using AutoMapper;
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
            #endregion

            #region ClubMapping
            CreateMap<Club, ClubDto>();
            CreateMap<CreateClubDto, Club>();
            CreateMap<UpdateClubDto, Club>();
            CreateMap<DeleteClubDto, Club>();
            #endregion

            #region ClubPeriodMapping
            CreateMap<ClubPeriod, ClubPeriodDto>().ReverseMap();
            CreateMap<CreateClubPeriodDto, ClubPeriod>();
            CreateMap<UpdateClubPeriodDto, ClubPeriod>();
            CreateMap<DeleteClubPeriodDto, ClubPeriod>();
            #endregion

            #region ClubRoleMapping
            CreateMap<ClubRole, ClubRoleDto>().ReverseMap();
            CreateMap<CreateClubRoleDto, ClubRole>();
            CreateMap<UpdateClubRoleDto, ClubRole>();
            CreateMap<DeleteClubRoleDto, ClubRole>();
            #endregion

            #region ClubTaskMapping
            CreateMap<ClubTask, ClubTaskDto>().ReverseMap();
            CreateMap<CreateClubTaskDto, ClubTask>();
            CreateMap<UpdateClubTaskDto, ClubTask>();
            CreateMap<DeleteClubTaskDto, ClubTask>();
            #endregion

            #region DepartmentMapping
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();
            CreateMap<DeleteDepartmentDto, Department>();
            #endregion

            #region EventMapping
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
            CreateMap<DeleteEventDto, Event>();
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
            CreateMap<Person, StudentDto>().ReverseMap();
            CreateMap<CreateStudentDto, Person>().ForSourceMember(x => x.Password, opt => opt.DoNotValidate());
            CreateMap<UpdateStudentDto, Person>();
            #endregion
        }
    }
}
