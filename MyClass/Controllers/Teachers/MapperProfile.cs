using AutoMapper;
using MyClass.Controllers.Teachers.ViewModels;
using Query.Teachers.GetAboutInfo;
using Query.Teachers.GetAllStudentTeachersByStudentId;
using Query.Teachers.GetAllTeachersWithIds;
using Query.Teachers.GetClassesWithStudentsNumber;

namespace MyClass.Controllers.Teachers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherListDto, AllTeachersForStudentViewModel>();
            CreateMap<IEnumerable<TeacherListDto>, IEnumerable<AllTeachersForStudentViewModel>>();

            CreateMap<TeacherDto, TeacherViewModel>();
            CreateMap<IEnumerable<TeacherDto>, IEnumerable<TeacherViewModel>>();

            CreateMap<AboutInfoDto, AboutInfoViewModel>();

            CreateMap<ClassesWithStudentsNumberDto, ClassesWithStudentsNumberViewModel>();
            CreateMap<IEnumerable<ClassesWithStudentsNumberDto>, IEnumerable<ClassesWithStudentsNumberViewModel>>();
        }

    }
}
