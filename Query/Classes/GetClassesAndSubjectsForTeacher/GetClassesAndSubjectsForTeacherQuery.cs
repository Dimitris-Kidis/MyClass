using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Classes.GetClassesAndSubjectsForTeacher
{
    public class GetClassesAndSubjectsForTeacherQuery : IRequest<IEnumerable<ClassAndSubjectDto>>
    {
        public int UserId { get; set; }
    }
}
