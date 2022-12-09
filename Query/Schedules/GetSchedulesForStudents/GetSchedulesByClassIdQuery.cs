using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetSchedulesForStudents
{
    public class GetSchedulesByClassIdQuery : IRequest<IEnumerable<ScheduleDto>>
    {
        public int ClassId { get; set; }
    }
}
