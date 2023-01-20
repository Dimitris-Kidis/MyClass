using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Grades.GetGradeLine
{
    public class GetGradeLineQuery : IRequest<GradeLineDto>
    {
        public int GradeId { get; set; }
    }
}
