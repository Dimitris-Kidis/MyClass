using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Classes.GetClassesAndSubjectsForTeacher
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Class, ClassAndSubjectDto>();
            CreateMap<IEnumerable<Class>, IEnumerable<ClassAndSubjectDto>>();
        }
    }
}
