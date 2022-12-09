using AutoMapper;
using MyClass.Controllers.Subjects.ViewModels;
using Query.Subjects.GetAllSubjectsWithIds;

namespace MyClass.Controllers.Subjects
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SubjectDto, SubjectViewModel>();
            CreateMap<IEnumerable<SubjectDto>, IEnumerable<SubjectViewModel>>();
        }

    }
}
