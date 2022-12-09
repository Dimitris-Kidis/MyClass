using AutoMapper;
using MyClass.Controllers.Students.ViewModels;
using Query.Grades.GetGradesWithAbsents;
using Query.Students.GetAboutInfo;
using Query.Students.GetAllClassmates;
using Query.Subjects.GetSubjectList;
using Query.Teachers.GetAboutInfo;
using AboutInfoDto = Query.Students.GetAboutInfo.AboutInfoDto;

namespace MyClass.Controllers.Students
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AboutInfoDto, AboutInfoViewModel>();

            CreateMap<SubjectDto, SubjectsWithTeachersViewModel>();
            CreateMap<IEnumerable<SubjectDto>, IEnumerable<SubjectsWithTeachersViewModel>>();

            CreateMap<ClassmatesDto, ClassmatesViewModel>();
            CreateMap<IEnumerable<ClassmatesDto>, IEnumerable<ClassmatesViewModel>>();

            CreateMap<GradesWithAbsentsDto, GradesWithAbsentsViewModel>();
            CreateMap<IEnumerable<GradesWithAbsentsDto>, IEnumerable<GradesWithAbsentsViewModel>>();
        }

    }
}
