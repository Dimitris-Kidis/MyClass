using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Subjects.CreateSubject
{
    public class CreateSubjectCommand : IRequest<int>
    {
        public string SubjectName { get; set; }
    }
}
