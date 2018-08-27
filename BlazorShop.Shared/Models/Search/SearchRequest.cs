using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.Models.Search
{
    public class SearchRequest
    {
        public string FreeTextFilter { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Category Category { get; set; }
    }
}
