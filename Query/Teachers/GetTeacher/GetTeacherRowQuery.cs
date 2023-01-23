using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetTeacher
{
    public class GetTeacherRowQuery : IRequest<TeacherRowDto>
    {
        public int UserId { get; set; }
    }
}
