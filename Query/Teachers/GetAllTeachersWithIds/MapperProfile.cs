using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetAllTeachersWithIds
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherDto, TeacherDto>();
            CreateMap<IEnumerable<TeacherDto>, IEnumerable<TeacherDto>>();
        }
    }
}
