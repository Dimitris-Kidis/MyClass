using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetAllTeachersWithIds
{
    public class GetAllTeachersWithIdsQuery : IRequest<IEnumerable<TeacherDto>>
    {
    }
}
