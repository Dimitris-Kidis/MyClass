﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetClassesWithStudentsNumber
{
    public class ClassesWithStudentsNumberDto
    {
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
