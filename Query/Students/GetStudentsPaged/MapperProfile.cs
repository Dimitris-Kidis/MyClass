using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetStudentsPaged
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<PagedStudentsDto, GetPagedStudentsDto>();

            CreateMap<IEnumerable<PagedStudentsDto>, IEnumerable<GetPagedStudentsDto>>();

        }
    }
}
