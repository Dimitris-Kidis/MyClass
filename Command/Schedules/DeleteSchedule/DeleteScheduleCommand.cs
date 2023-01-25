using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Schedules.DeleteSchedule
{
    public class DeleteScheduleCommand : IRequest<int>
    {
        public int ScheduleId { get; set; }
    }
}
