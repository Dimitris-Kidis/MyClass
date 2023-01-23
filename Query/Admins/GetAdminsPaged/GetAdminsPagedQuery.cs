using MediatR;
using Query.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Admins.GetAdminsPaged
{
    public class GetAdminsPagedQuery : IRequest<PaginatedResult<GetPagedAdminsDto>>
    {
        public GetAdminsPagedQuery()
        {
            RequestFilters = new RequestFilters();
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string ColumnNameForSorting { get; set; }

        public string SortDirection { get; set; }

        public RequestFilters RequestFilters { get; set; }
    }
}
