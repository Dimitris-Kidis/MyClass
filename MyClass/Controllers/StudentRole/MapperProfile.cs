using AutoMapper;
using MyClass.Controllers.Common.ViewModels;
//using MyClass.Controllers.Student.ViewModels;
using MyClass.Controllers.StudentRole.ViewModels;
using Query.Grades.GetGradesWithAbsents;
using Query.Schedules.GetScheduleInfo;
using Query.Schedules.GetSchedulesForStudents;
using Query.Students.GetAboutInfo;
using Query.Students.GetAllClassmates;
using Query.Subjects.GetSubjectList;
using Query.Teachers.GetAboutInfo;
using Query.Teachers.GetAllStudentTeachersByStudentId;
using Query.Teachers.GetAllTeachersWithIds;
using AboutInfoDto = Query.Students.GetAboutInfo.AboutInfoDto;

namespace MyClass.Controllers.Student
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AboutInfoDto, AboutInfoViewModel>();

            CreateMap<SubjectDto, SubjectsWithTeachersViewModel>();
            CreateMap<IEnumerable<SubjectDto>, IEnumerable<SubjectsWithTeachersViewModel>>();

            CreateMap<ClassmatesDto, ClassmatesViewModel>();
            CreateMap<IEnumerable<ClassmatesDto>, IEnumerable<ClassmatesViewModel>>();

            CreateMap<GradesWithAbsentsDto, GradesWithAbsentsViewModel>();
            CreateMap<IEnumerable<GradesWithAbsentsDto>, IEnumerable<GradesWithAbsentsViewModel>>();

            CreateMap<Query.Schedules.GetSchedulesForStudents.ScheduleDto, MyClass.Controllers.StudentRole.ViewModels.ScheduleViewModel>();
            CreateMap<IEnumerable<Query.Schedules.GetSchedulesForStudents.ScheduleDto>, IEnumerable<MyClass.Controllers.StudentRole.ViewModels.ScheduleViewModel>>();

            CreateMap<TeacherListDto, AllTeachersForStudentViewModel>();
            CreateMap<IEnumerable<TeacherListDto>, IEnumerable<AllTeachersForStudentViewModel>>();


        }

    }
}
