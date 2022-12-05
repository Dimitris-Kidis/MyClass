using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetAboutInfo
{
    public class AboutInfoDto
    {
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string ClassName { get; set; }
        public int NumberOfSubjects { get; set; }
        public int NumberOfClassMates { get; set; }
        public int NumberOfTeachers { get; set; }
    }
}
