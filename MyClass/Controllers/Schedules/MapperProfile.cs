using AutoMapper;
using MyClass.Controllers.Schedules.ViewModels;
using Query.Schedules.GetSchedulesForStudents;
using Query.Schedules.GetSchedulesForTeachers;

namespace MyClass.Controllers.Schedules
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ScheduleDto, ScheduleViewModel>();
            CreateMap<IEnumerable<ScheduleDto>, IEnumerable<ScheduleViewModel>>();

            CreateMap<ScheduleForTeachersDto, ScheduleForTeachersViewModel>();
            CreateMap<IEnumerable<ScheduleForTeachersDto>, IEnumerable<ScheduleForTeachersViewModel>>();
        }

    }
}
