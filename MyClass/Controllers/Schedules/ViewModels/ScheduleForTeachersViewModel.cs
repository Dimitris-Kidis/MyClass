namespace MyClass.Controllers.Schedules.ViewModels
{
    public class ScheduleForTeachersViewModel
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string LessonName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset DateAndTime { get; set; }
        public string Cabinet { get; set; }
    }
}
