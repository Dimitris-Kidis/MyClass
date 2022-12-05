using AutoMapper;
using MyClass.Controllers.Students.ViewModels;
using Query.Students.GetAboutInfo;
using Query.Students.GetAllClassmates;
using Query.Subjects.GetSubjectList;

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
        }

    }
}
