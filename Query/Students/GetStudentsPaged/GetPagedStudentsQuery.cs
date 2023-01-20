using MediatR;
using Query.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Students.GetStudentsPaged
{
    public class GetPagedStudentsQuery : IRequest<PaginatedResult<GetPagedStudentsDto>>
    {
        public GetPagedStudentsQuery()
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
