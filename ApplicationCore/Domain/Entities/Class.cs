using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Class : BaseEntity
    {
        public string ClassName { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<ClassTeacher> ClassesTeachers { get; set; }
    }
}
