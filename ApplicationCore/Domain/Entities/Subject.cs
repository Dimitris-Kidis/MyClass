using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<ClassTeacher> ClassesTeachers { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        //public ICollection<AbsentList> AbsentLists { get; set; }
    }
}
