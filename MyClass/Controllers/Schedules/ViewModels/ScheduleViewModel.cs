namespace MyClass.Controllers.Schedules.ViewModels
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string LessonName { get; set; }
        public string TeacherName { get; set; }
        public DateTimeOffset DateAndTime { get; set; }
        public string Cabinet { get; set; }
    }
}
