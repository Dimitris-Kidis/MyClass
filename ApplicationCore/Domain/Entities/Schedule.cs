using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int LessonTypeId { get; set; }
        public LessonType LessonType { get; set; }
        public DateTimeOffset DateAndTime { get; set; }
        public string Cabinet { get; set; }

    }
}
