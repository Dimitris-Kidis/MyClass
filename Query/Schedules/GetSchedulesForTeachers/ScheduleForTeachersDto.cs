using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetSchedulesForTeachers
{
    public class ScheduleForTeachersDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string LessonName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset DateAndTime { get; set; }
        public string Cabinet { get; set; }
    }
}
