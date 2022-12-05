using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Improvements.CreateNewImprovement
{
    public class CreateNewImprovementCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string HelpNote { get; set; }
    }
}
