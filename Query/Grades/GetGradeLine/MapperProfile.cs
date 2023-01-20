using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradeLine
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Grade, GradeLineDto>();
            CreateMap<IEnumerable<Grade>, IEnumerable<GradeLineDto>>();
        }
    }
}
