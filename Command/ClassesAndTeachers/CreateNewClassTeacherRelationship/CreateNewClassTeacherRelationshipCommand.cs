using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.ClassesAndTeachers.CreateNewClassTeacherRelationship
{
    public class CreateNewClassTeacherRelationshipCommand : IRequest<int>
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
