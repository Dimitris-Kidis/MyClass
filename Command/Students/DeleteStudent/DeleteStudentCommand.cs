using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Students.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
