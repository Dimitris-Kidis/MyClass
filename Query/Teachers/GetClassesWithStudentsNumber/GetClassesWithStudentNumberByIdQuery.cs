using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetClassesWithStudentsNumber
{
    public class GetClassesWithStudentNumberByIdQuery : IRequest<IEnumerable<ClassesWithStudentsNumberDto>>
    {
        public int UserId { get; set; }
    }
}
