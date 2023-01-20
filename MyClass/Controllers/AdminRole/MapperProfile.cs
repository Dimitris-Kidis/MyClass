using AutoMapper;
using MyClass.Controllers.AdminRole.ViewModels;
using Query.Classes.GetAllClassesWithIds;
using Query.Classes.GetClassesAndSubjectsForTeacher;
using Query.Improvements.GetAllImprovements;
using Query.Subjects.GetAllSubjectsWithIds;
using Query.Teachers.GetAllTeachersWithIds;

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
        }

    }
}
