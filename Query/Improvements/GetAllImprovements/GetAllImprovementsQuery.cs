using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Improvements.GetAllImprovements
{
    public class GetAllImprovementsQuery : IRequest<IEnumerable<ImprovementDto>>
    {
    }
}
