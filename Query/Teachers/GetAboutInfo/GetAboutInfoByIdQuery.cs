using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Teachers.GetAboutInfo
{
    public class GetAboutInfoByIdQuery : IRequest<AboutInfoDto>
    {
        public int Id { get; set; }
    }
}
