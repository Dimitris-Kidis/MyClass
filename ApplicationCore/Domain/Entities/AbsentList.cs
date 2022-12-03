using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class AbsentList : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int Courses { get; set; }
        public int Labs { get; set; }
        public int Seminars { get; set; }
    }
}
