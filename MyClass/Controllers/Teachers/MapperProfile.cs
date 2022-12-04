using AutoMapper;
using MyClass.Controllers.Teachers.ViewModels;
using Query.Teachers.GetAllStudentTeachersByStudentId;

namespace MyClass.Controllers.Teachers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherListDto, AllTeachersForStudentViewModel>();
            CreateMap<IEnumerable<TeacherListDto>, IEnumerable<AllTeachersForStudentViewModel>>();

        }

    }
}
