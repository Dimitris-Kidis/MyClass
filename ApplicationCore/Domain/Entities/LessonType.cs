using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class LessonType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

    }
}
