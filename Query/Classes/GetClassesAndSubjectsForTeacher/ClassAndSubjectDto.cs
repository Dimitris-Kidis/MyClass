using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Classes.GetClassesAndSubjectsForTeacher
{
    public class ClassAndSubjectDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
