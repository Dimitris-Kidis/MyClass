using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetAllClassmates
{
    public class GetAllClassmatesQuery : IRequest<IEnumerable<ClassmatesDto>>
    {
        public int ClassId { get; set; }
    }
}
