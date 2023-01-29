using AutoMapper;
using MyClass.Controllers.AdminRole.ViewModels;
using Query.Admins.GetAdminAboutInfo;
using Query.Classes.GetAllClassesWithIds;
using Query.Classes.GetClassesAndSubjectsForTeacher;
using Query.Improvements.GetAllImprovements;
using Query.Posts.GetOnePost;
using Query.Relations.GetAllRelations;
using Query.Schedules.GetAllSchedules;
using Query.Students.GetStudent;
using Query.Subjects.GetAllSubjectsWithIds;
using Query.Teachers.GetAllTeachersWithIds;
using Query.Teachers.GetTeacher;

namespace MyClass.Controllers.AdminRole
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClassDto, ClassViewModel>();
            CreateMap<IEnumerable<ClassDto>, IEnumerable<ClassViewModel>>();

            CreateMap<ImprovementDto, ImprovementViewModel>();
            CreateMap<IEnumerable<ImprovementDto>, IEnumerable<ImprovementViewModel>>();

            CreateMap<SubjectDto, SubjectViewModel>();
            CreateMap<IEnumerable<SubjectDto>, IEnumerable<SubjectViewModel>>();

            CreateMap<TeacherDto, TeacherViewModel>();
            CreateMap<IEnumerable<TeacherDto>, IEnumerable<TeacherViewModel>>();

            CreateMap<AdminAboutInfoDto, AdminAboutInfoViewModel>();

            CreateMap<StudentOrAdminRowDto, StudentOrAdminRowViewModel>();

            CreateMap<TeacherRowDto, TeacherRowViewModel>();

            CreateMap<RelationDto, RelationViewModel>();
            CreateMap<IEnumerable<RelationDto>, IEnumerable<RelationViewModel>>();

            CreateMap<GetAllSchedulesDto, AllSchedulesViewModel>();
            CreateMap<IEnumerable<GetAllSchedulesDto>, IEnumerable<AllSchedulesViewModel>>();

            CreateMap<OnePostDto, OnePostViewModel>();


        }

    }
}
