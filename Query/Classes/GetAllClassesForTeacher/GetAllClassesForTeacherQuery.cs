using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Classes.GetAllClassesForTeacher
{
    public class GetAllClassesForTeacherQuery : IRequest<IEnumerable<ClassForTeacherDto>>
    {
        public int UserId { get; set; }
    }
}
