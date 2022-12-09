using ApplicationCore.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetSchedulesForTeachers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ScheduleForTeachersDto, ScheduleForTeachersDto>();
            CreateMap<IEnumerable<ScheduleForTeachersDto>, IEnumerable<ScheduleForTeachersDto>>();
        }
    }
}
