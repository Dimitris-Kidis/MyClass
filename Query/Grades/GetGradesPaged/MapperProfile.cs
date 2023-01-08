using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradesPaged
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<GetPagedGradesForClassIdAndSubjectIdDto, PagedGradesForClassAndSubjectDto>();

            CreateMap<IEnumerable<GetPagedGradesForClassIdAndSubjectIdDto>, IEnumerable<PagedGradesForClassAndSubjectDto>>();

        }
    }
}
