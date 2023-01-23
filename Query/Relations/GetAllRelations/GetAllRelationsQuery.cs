using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Relations.GetAllRelations
{
    public class GetAllRelationsQuery : IRequest<IEnumerable<RelationDto>>
    {
    }
}
