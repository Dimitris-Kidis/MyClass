using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Entities
{
    public class Teacher : BaseEntity
    {
        //public int UserId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<ClassTeacher> ClassesTeachers { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string SubjectName { get; set; }
         
    }
}
