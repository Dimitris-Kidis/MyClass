using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetSchedulesForStudents
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ScheduleDto, ScheduleDto>();
            CreateMap<IEnumerable<ScheduleDto>, IEnumerable<ScheduleDto>>();
        }
    }
}
