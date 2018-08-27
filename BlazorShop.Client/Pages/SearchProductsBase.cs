using BlazorShop.Client.Services;
using BlazorShop.Shared.Models;
using BlazorShop.Shared.Models.Search;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Threading.Tasks;

namespace BlazorShop.Client.Pages
{
    public class SearchProductsBase : BlazorComponent
    {
        // Injected services
        [Inject]
        private IDataService DataService { get; set; }
        [Inject]
        private Microsoft.AspNetCore.Blazor.Services.IUriHelper UriHelper { get; set; }
        [Parameter]
        private string CategoryParam { get; set; }

        // Properties
        public SearchRequest SearchRequest { get; set; }
        public SearchResult SearchResult { get; set; }
        public string SearchText { get; set; }
        public bool SearchInProgress { get; set; }

        public int CurrentPage { get; set; }
        public int ResultCount { get; set; } = 10;
        public Category SelectedCategory { get; set; }

        public int SelectedProductId { get; set; }
        public int Token { get; set; }
        public int GetNextToken()
        {
            return Token += 1;
        }

        protected async override Task OnInitAsync()
        {
            if (Enum.TryParse(CategoryParam, out Category parsedCategory))
            {
                SelectedCategory = parsedCategory;
            }
            await StartSearch();
        }

        public void SetCategory(UIChangeEventArgs args)
        {
            SelectedCategory = (Category)Enum.Parse(typeof(Category), args.Value.ToString());
        }

        public async Task StartSearch(int pageIndex = 0)
        {
            SearchInProgress = true;
            SelectedProductId = 0;
            SearchResult = null;
            SearchRequest = new SearchRequest
            {
                FreeTextFilter = SearchText?.Trim()?.ToLower() ?? string.Empty,
                PageIndex = pageIndex,
                PageSize = ResultCount,
                Category = SelectedCategory
            };

            SearchResult = await DataService.SearchProducts(SearchRequest);
            SearchInProgress = false;

            UriHelper.NavigateTo($"/search/{SelectedCategory}");
        }

        public async Task HandleEnterKey(UIKeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                await StartSearch();
            }
        }
    }
}
