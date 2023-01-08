using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Classes.CreateClass
{
    public class CreateClassCommand : IRequest<int>
    {
        public string ClassName { get; set; }
    }
}
