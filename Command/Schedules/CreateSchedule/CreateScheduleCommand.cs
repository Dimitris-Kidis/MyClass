using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Schedules.CreateSchedule
{
    public class CreateScheduleCommand : IRequest<int>
    {
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public string LessonName { get; set; }
        public DateTimeOffset DateAndTime { get; set; }
        public string Cabinet { get; set; }


    }
}
