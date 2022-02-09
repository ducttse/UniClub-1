using AutoMapper;
using UniClub.Application.ClubPeriods.Commands.CreateClubPeriod;
using UniClub.Application.ClubPeriods.Commands.DeleteClubPeriod;
using UniClub.Application.ClubPeriods.Commands.UpdateClubPeriod;
using UniClub.Application.ClubPeriods.Dtos;
using UniClub.Application.ClubRoles.Commands.CreateClubRole;
using UniClub.Application.ClubRoles.Commands.DeleteClubRole;
using UniClub.Application.ClubRoles.Commands.UpdateClubRole;
using UniClub.Application.ClubRoles.Dtos;
using UniClub.Application.Clubs.Commands.CreateClub;
using UniClub.Application.Clubs.Commands.DeleteClub;
using UniClub.Application.Clubs.Commands.UpdateClub;
using UniClub.Application.Clubs.Dtos;
using UniClub.Application.ClubTasks.Commands.CreateClubTask;
using UniClub.Application.ClubTasks.Commands.DeleteClubTask;
using UniClub.Application.ClubTasks.Commands.UpdateClubTask;
using UniClub.Application.ClubTasks.Dtos;
using UniClub.Application.Departments.Commands.CreateDepartment;
using UniClub.Application.Departments.Commands.DeleteDepartment;
using UniClub.Application.Departments.Commands.UpdateDepartment;
using UniClub.Application.Departments.Dtos;
using UniClub.Application.Events.Commands.CreateEvent;
using UniClub.Application.Events.Commands.DeleteEvent;
using UniClub.Application.Events.Commands.UpdateEvent;
using UniClub.Application.Events.Dtos;
using UniClub.Application.Members.Commands.CreateMember;
using UniClub.Application.Members.Commands.DeleteMember;
using UniClub.Application.Members.Commands.UpdateMember;
using UniClub.Application.Members.Dtos;
using UniClub.Application.PostImages.Commands.CreatePostImage;
using UniClub.Application.PostImages.Commands.DeletePostImage;
using UniClub.Application.PostImages.Commands.UpdatePostImage;
using UniClub.Application.PostImages.Dtos;
using UniClub.Application.Posts.Commands.CreatePost;
using UniClub.Application.Posts.Commands.DeletePost;
using UniClub.Application.Posts.Commands.UpdatePost;
using UniClub.Application.Posts.Dtos;
using UniClub.Application.Students.Commands.CreateStudent;
using UniClub.Application.Students.Commands.UpdateStudent;
using UniClub.Application.Students.Dtos;
using UniClub.Application.Universities.Commands.CreateUniversity;
using UniClub.Application.Universities.Commands.DeleteUniversity;
using UniClub.Application.Universities.Commands.UpdateUniversity;
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

            #region ClubMapping
            CreateMap<Club, ClubDto>()
                .ForMember(dto => dto.UniName,
                o => o.MapFrom(e => e.Uni.UniName))
                .ForMember(dto => dto.UniShortName,
                o => o.MapFrom(e => e.Uni.ShortName));
            CreateMap<CreateClubCommand, Club>();
            CreateMap<UpdateClubCommand, Club>();
            CreateMap<DeleteClubCommand, Club>();
            #endregion

            #region ClubPeriodMapping
            CreateMap<ClubPeriod, ClubPeriodDto>().ReverseMap();
            CreateMap<CreateClubPeriodCommand, ClubPeriod>();
            CreateMap<UpdateClubPeriodCommand, ClubPeriod>();
            CreateMap<DeleteClubPeriodCommand, ClubPeriod>();
            #endregion

            #region ClubRoleMapping
            CreateMap<ClubRole, ClubRoleDto>().ReverseMap();
            CreateMap<CreateClubRoleCommand, ClubRole>();
            CreateMap<UpdateClubRoleCommand, ClubRole>();
            CreateMap<DeleteClubRoleCommand, ClubRole>();
            #endregion

            #region ClubTaskMapping
            CreateMap<ClubTask, ClubTaskDto>().ReverseMap();
            CreateMap<CreateClubTaskCommand, ClubTask>();
            CreateMap<UpdateClubTaskCommand, ClubTask>();
            CreateMap<DeleteClubTaskCommand, ClubTask>();
            #endregion

            #region DepartmentMapping
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();
            CreateMap<DeleteDepartmentCommand, Department>();
            #endregion

            #region EventMapping
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<CreateEventCommand, Event>();
            CreateMap<UpdateEventCommand, Event>();
            CreateMap<DeleteEventCommand, Event>();
            #endregion

            #region MemberMapping
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<CreateMemberCommand, Member>();
            CreateMap<UpdateMemberCommand, Member>();
            CreateMap<DeleteMemberCommand, Member>();
            #endregion

            #region PostMapping
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<CreatePostCommand, Post>();
            CreateMap<UpdatePostCommand, Post>();
            CreateMap<DeletePostCommand, Post>();
            #endregion

            #region PostImageMapping
            CreateMap<PostImage, PostImageDto>().ReverseMap();
            CreateMap<CreatePostImageCommand, PostImage>();
            CreateMap<UpdatePostImageCommand, PostImage>();
            CreateMap<DeletePostImageCommand, PostImage>();
            #endregion

            #region Student
            CreateMap<Person, StudentDto>().ReverseMap();
            CreateMap<CreateStudentCommand, Person>().ForSourceMember(x => x.Password, opt => opt.DoNotValidate());
            CreateMap<UpdateStudentCommand, Person>();
            #endregion
        }
    }
}
