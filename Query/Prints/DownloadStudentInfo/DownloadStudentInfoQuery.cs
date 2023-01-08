using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Prints.DownloadStudentInfo
{
    public class DownloadStudentInfoQuery : IRequest<Stream>
    {
        public int UserId { get; set; }
    }
}
