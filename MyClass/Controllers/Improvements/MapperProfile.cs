using AutoMapper;
using MyClass.Controllers.Improvements.ViewModels;
using Query.Improvements.GetAllImprovements;

namespace MyClass.Controllers.Improvements
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ImprovementDto, ImprovementViewModel>();
            CreateMap<IEnumerable<ImprovementDto>, IEnumerable<ImprovementViewModel>>();
        }

    }
}
