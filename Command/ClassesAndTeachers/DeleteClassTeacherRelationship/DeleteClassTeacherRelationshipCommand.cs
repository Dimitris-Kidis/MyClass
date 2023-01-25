using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.ClassesAndTeachers.DeleteClassTeacherRelationship
{
    public class DeleteClassTeacherRelationshipCommand : IRequest<int>
    {
        public int ClassTeacherId { get; set; }
    }
}
