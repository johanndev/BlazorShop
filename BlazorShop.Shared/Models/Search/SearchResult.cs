using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorShop.Shared.Models.Search
{
    public class SearchResult
    {
        public SearchResultOverview Overview { get; set; }
        public IList<SearchResultItem> ResultItems{ get; set; }
    }
}
