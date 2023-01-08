﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Prints.DownloadTeacherInfo
{
    public class DownloadTeacherInfoQuery : IRequest<Stream>
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
        
    }
}
