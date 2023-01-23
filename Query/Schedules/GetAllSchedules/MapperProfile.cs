using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetAllSchedules
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GetAllSchedulesDto, GetAllSchedulesDto>();
            CreateMap<IEnumerable<GetAllSchedulesDto>, IEnumerable<GetAllSchedulesDto>>();
        }
    }
}
