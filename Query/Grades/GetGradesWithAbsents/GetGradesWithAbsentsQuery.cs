using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradesWithAbsents
{
    public class GetGradesWithAbsentsQuery : IRequest<IEnumerable<GradesWithAbsentsDto>>
    {
        public int StudentId { get; set; }
    }
}
