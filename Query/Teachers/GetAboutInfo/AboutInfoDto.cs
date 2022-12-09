using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetAboutInfo
{
    public class AboutInfoDto
    {
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public int NumberOfSubjects { get; set; }
        public int NumberOfClasses { get; set; }
    }
}
