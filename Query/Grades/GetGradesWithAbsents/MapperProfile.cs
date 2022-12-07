using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradesWithAbsents
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GradesWithAbsentsDto, GradesWithAbsentsDto>();
            CreateMap<IEnumerable<GradesWithAbsentsDto>, IEnumerable<GradesWithAbsentsDto>>();
        }
    }
}
