using BlazorShop.Client.Services;
using BlazorShop.Shared.Models.Search;
using Microsoft.AspNetCore.Blazor.Components;
using System.Threading.Tasks;

namespace BlazorShop.Client.Pages
{
    public class SearchProductsBase : BlazorComponent
    {
        // Injected services
        [Inject]
        private IDataService DataService { get; set; }

        // Properties
        public SearchRequest SearchRequest { get; set; }
        public SearchResult SearchResult { get; set; }
        public string SearchText { get; set; }

        public int CurrentPage { get; set; } = 0;
        public int ResultCount { get; set; } = 10;

        public int SelectedProductId { get; set; } = 0;

        protected async override Task OnInitAsync()
        {
            await StartSearch();
        }

        public async Task StartSearch()
        {
            SearchResult = null;
            var searchRequest = new SearchRequest
            {
                FreeTextFilter = SearchText?.Trim()?.ToLower() ?? string.Empty,
                PageIndex = 0,
                PageSize = ResultCount
            };

            SearchResult = await DataService.SearchProducts(searchRequest);
        }
    }
}
