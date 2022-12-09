using ApplicationCore.Domain.Entities;
using AutoMapper;
using Query.Grades.GetGradesWithAbsents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Subjects.GetAllSubjectsWithIds
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<IEnumerable<Subject>, IEnumerable<SubjectDto>>();
        }
    }
}
