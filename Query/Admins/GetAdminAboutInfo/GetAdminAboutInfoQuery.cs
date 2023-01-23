using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Admins.GetAdminAboutInfo
{
    public class GetAdminAboutInfoQuery : IRequest<AdminAboutInfoDto>
    {
        public int UserId { get; set; }
    }
}
