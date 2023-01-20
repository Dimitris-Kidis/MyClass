using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Schedules.GetScheduleInfo
{
    public class GetScheduleQuery : IRequest<ScheduleDto>
    {
        public int ScheduleId { get; set; }
    }
}
