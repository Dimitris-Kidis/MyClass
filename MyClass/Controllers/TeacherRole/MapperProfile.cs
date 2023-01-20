using AutoMapper;
using MyClass.Controllers.AdminRole.ViewModels;
using MyClass.Controllers.TeacherRole.ViewModels;
using Query.Classes.GetAllClassesForTeacher;
using Query.Classes.GetClassesAndSubjectsForTeacher;
using Query.Grades.GetGradeLine;
using Query.Schedules.GetSchedulesForTeachers;
using Query.Teachers.GetAboutInfo;
using Query.Teachers.GetClassesWithStudentsNumber;

namespace MyClass.Controllers.Teacher
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ScheduleForTeachersDto, ScheduleForTeachersViewModel>();
            CreateMap<IEnumerable<ScheduleForTeachersDto>, IEnumerable<ScheduleForTeachersViewModel>>();

            CreateMap<AboutInfoDto, AboutInfoViewModel>();

            CreateMap<ClassesWithStudentsNumberDto, ClassesWithStudentsNumberViewModel>();
            CreateMap<IEnumerable<ClassesWithStudentsNumberDto>, IEnumerable<ClassesWithStudentsNumberViewModel>>();

            CreateMap<ClassForTeacherDto, ClassForTeacherViewModel>();
            CreateMap<IEnumerable<ClassForTeacherDto>, IEnumerable<ClassForTeacherViewModel>>();

            CreateMap<ClassAndSubjectDto, ClassAndSubjectViewModel>();
            CreateMap<IEnumerable<ClassAndSubjectDto>, IEnumerable<ClassAndSubjectViewModel>>();

            CreateMap<GradeLineDto, GradeLineViewModel>();
        }

    }
}


