using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Subjects.GetSubjectList
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SubjectDto, SubjectDto>();
            CreateMap<IEnumerable<SubjectDto>, IEnumerable<SubjectDto>>();
        }
    }
}
