using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetSchedulesForStudents
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string LessonName { get; set; }
        public string TeacherName { get; set; }
        public DateTimeOffset DateAndTime { get; set; }
        public string Cabinet { get; set; }
    }
}
