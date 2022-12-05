using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetAboutInfo
{
    public class GetAboutInfoByIdQuery : IRequest<AboutInfoDto>
    {
        public int Id { get; set; }
    }
}
