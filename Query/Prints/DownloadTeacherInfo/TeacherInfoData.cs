using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Prints.DownloadTeacherInfo
{
    public class TeacherInfoData
    {
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string JoinedOn { get; set; }
        public string AvatarLink { get; set; }
        public int NumberOfClasses { get; set; }
        public int NumberOfSubjects { get; set; }
        public string ActualDate { get; set; }
        public string ClassName { get; set; }
    }
}
