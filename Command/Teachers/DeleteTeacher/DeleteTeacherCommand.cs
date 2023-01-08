using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Teachers.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
