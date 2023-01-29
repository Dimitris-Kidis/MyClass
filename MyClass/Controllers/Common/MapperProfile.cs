using AutoMapper;
using MyClass.Controllers.Common.ViewModels;
using Query.Notes.GetAllNotes;
using Query.Posts.GetAllPosts;
using Query.Schedules.GetScheduleInfo;
using Query.Users.GetUser;

namespace MyClass.Controllers.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NotesDto, NotesViewModel>();
            CreateMap<IEnumerable<NotesDto>, IEnumerable<NotesViewModel>>();

            CreateMap<UserDto, UserViewModel>();

            CreateMap<ScheduleDto, ScheduleViewModel>();
            //CreateMap<IEnumerable<Query.Schedules.GetScheduleInfo.ScheduleDto>, IEnumerable<ScheduleViewModel>>();

            CreateMap<PostDto, PostViewModel>();
            CreateMap<IEnumerable<PostDto>, IEnumerable<PostViewModel>>();

        }

    }
}
