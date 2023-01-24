using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Subjects.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest<int>
    {
        public int SubjectId { get; set; }
    }
}
