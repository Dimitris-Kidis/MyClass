using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Prints.DownloadPersonalInfo
{
    public class DownloadPersonalInfoQuery : IRequest<Stream>
    {
        public int UserId { get; set; }
    }
}
