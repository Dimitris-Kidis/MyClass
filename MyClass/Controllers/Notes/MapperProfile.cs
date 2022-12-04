using AutoMapper;
using MyClass.Controllers.Notes.ViewModels;
using Query.Notes.GetAllNotes;

namespace MyClass.Controllers.Notes
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NotesDto, NotesViewModel>();
            CreateMap<IEnumerable<NotesDto>, IEnumerable<NotesViewModel>>();

        }

    }
}
