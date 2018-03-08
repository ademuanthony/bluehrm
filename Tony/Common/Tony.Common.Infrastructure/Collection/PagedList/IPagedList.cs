﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tony.Common.Infrastructure.Collection.PagedList
{
    public interface IPagedList<T>:IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
