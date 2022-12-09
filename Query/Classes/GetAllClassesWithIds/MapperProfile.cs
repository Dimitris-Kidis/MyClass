﻿using ApplicationCore.Domain.Entities;
using AutoMapper;
using Query.Grades.GetGradesWithAbsents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Classes.GetAllClassesWithIds
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Class, ClassDto>();
            CreateMap<IEnumerable<Class>, IEnumerable<ClassDto>>();
        }
    }
}
