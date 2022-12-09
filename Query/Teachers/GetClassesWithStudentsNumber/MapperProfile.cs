using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetClassesWithStudentsNumber
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClassesWithStudentsNumberDto, ClassesWithStudentsNumberDto>();
            CreateMap<IEnumerable<ClassesWithStudentsNumberDto>, IEnumerable<ClassesWithStudentsNumberDto>>();
        }
    }
}
