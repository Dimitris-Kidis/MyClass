using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Subjects.GetSubjectList
{
    public class GetSubjectListQuery : IRequest<IEnumerable<SubjectDto>>
    {
        public int ClassId { get; set; }
    }
}
