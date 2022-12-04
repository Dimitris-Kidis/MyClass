using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Notes.GetAllNotes
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Note, NotesDto>();
            CreateMap<IEnumerable<Note>, IEnumerable<NotesDto>>();
        }
    }
}
