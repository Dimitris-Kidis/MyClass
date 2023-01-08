using AutoMapper;
using MyClass.Controllers.Classes.ViewModels;
using Query.Classes.GetAllClassesWithIds;
using Query.Classes.GetClassesAndSubjectsForTeacher;

namespace MyClass.Controllers.Classes
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClassDto, ClassViewModel>();
            CreateMap<IEnumerable<ClassDto>, IEnumerable<ClassViewModel>>();

            CreateMap<ClassAndSubjectDto, ClassAndSubjectViewModel>();
            CreateMap<IEnumerable<ClassAndSubjectDto>, IEnumerable<ClassAndSubjectViewModel>>();
        }

    }
}
