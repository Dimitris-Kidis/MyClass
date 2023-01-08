using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Grades.UpdateGradeLine
{
    public class UpdateGradeLineCommand : IRequest<int>
    {
        public int Id { get; set; }
        public float GradeOne { get; set; }
        public float GradeTwo { get; set; }
        public float GradeThree { get; set; }
        public float GradeFour { get; set; }
        public int Courses { get; set; }
        public int Labs { get; set; }
        public int Seminars { get; set; }
    }
}
