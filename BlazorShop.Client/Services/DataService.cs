using BlazorShop.Shared.Models;
using BlazorShop.Shared.Models.Search;
using Microsoft.AspNetCore.Blazor;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient Http;

        public DataService(HttpClient http)
        {
            Http = http;
        }

        public async Task<Product> GetProductDetails(int productId)
        {
            return await Http.GetJsonAsync<Product>($"api/Product/{productId}");
        }

        public async Task<SearchResult> SearchProducts(SearchRequest searchRequest)
        {
            return await Http.PostJsonAsync<SearchResult>("api/Product/Search", searchRequest);

        }
    }
}
