using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetTeachersPaged
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<PagedTeachersDto, GetPagedTeachersDto>();

            CreateMap<IEnumerable<PagedTeachersDto>, IEnumerable<GetPagedTeachersDto>>();

        }
    }
}
