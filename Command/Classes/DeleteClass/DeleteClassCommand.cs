using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Classes.DeleteClass
{
    public class DeleteClassCommand : IRequest<int>
    {
        public int ClassId { get; set; }
    }
}
