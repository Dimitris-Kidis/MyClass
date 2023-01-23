using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetStudent
{
    public class GetStudentOrAdminQuery : IRequest<StudentOrAdminRowDto>
    {
        public int UserId { get; set; }
    }
}
