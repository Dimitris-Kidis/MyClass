using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetSchedulesForTeachers
{
    public class GetSchedulesByUserIdQuery : IRequest<IEnumerable<ScheduleForTeachersDto>>
    {
        public int UserId { get; set; }
    }
}
