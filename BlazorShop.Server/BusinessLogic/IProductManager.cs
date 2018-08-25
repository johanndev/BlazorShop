using BlazorShop.Shared.Models;
using BlazorShop.Shared.Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorShop.Server.BusinessLogic
{
    public interface IProductManager
    {
        Task<Product> GetProduct(int productId);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<SearchResult> SearchProducts(SearchRequest searchRequest);
    }
}