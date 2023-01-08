using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Classes.GetAllClassesForTeacher
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Class, ClassForTeacherDto>();
            CreateMap<IEnumerable<Class>, IEnumerable<ClassForTeacherDto>>();
        }
    }
}
