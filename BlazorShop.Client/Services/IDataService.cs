using BlazorShop.Shared.Models;
using BlazorShop.Shared.Models.Search;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services
{
    interface IDataService
    {
        Task<SearchResult> SearchProducts(SearchRequest searchRequest);
        Task<Product> GetProductDetails(int productId);
    }
}
