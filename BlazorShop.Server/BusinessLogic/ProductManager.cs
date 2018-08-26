using BlazorShop.Server.Data;
using BlazorShop.Shared.Models;
using BlazorShop.Shared.Models.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.BusinessLogic
{
    public class ProductManager : IProductManager
    {
        private readonly BlazorShopDbContext blazorShopDbContext;

        public ProductManager(BlazorShopDbContext blazorShopDbContext)
        {
            this.blazorShopDbContext = blazorShopDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await blazorShopDbContext.Products
                .Take(10)
                .ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            var result = await blazorShopDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            return result;
        }

        public async Task<SearchResult> SearchProducts(SearchRequest searchRequest)
        {
            if (searchRequest == null)
            {
                throw new ArgumentNullException(nameof(searchRequest));
            }

            IQueryable<Product> query = blazorShopDbContext.Products;

            var searchText = searchRequest.FreeTextFilter?.Trim().ToLower() ?? string.Empty;

            if (searchText.Any())
            {
                query = query
                    .Where(p =>
                            p.Title.ToLower().Contains(searchText)
                            || p.HtmlDescription.ToLower().Contains(searchText)
                            || p.ImageAltText.ToLower().Contains(searchText)
                            || p.Vendor.ToLower().Contains(searchText)
                            || p.Tags.ToLower().Contains(searchText)
                            || p.VariantBarcode.ToLower().Contains(searchText)
                            || p.Option1Value.ToLower().Contains(searchText)
                            || p.Option2Value.ToLower().Contains(searchText)
                            || p.Option3Value.ToLower().Contains(searchText)
                        );
            }

            query = query.Where(p => p.Title.Length > 0);

            var totalResults = await query.CountAsync();

            // Paging 
            if (searchRequest.PageIndex > 0)
            {
                query = query.Skip(searchRequest.PageIndex * searchRequest.PageSize);
            }
            query = query.Take(searchRequest.PageSize);

            // Materialize
            var items = await query
                .AsNoTracking()
                .ToListAsync();

            var results = items.Select(p =>
            {
                return new SearchResultItem
                {
                    Id = p.Id,
                    Category = p.Category,
                    Vendor = p.Vendor,
                    HtmlDescription = p.HtmlDescription,
                    ImageAltText = p.ImageAltText,
                    ImageSrc = p.ImageSrc,
                    Tags = p.Tags,
                    Title = p.Title,
                    Type = p.Type,
                    VariantGrams = p.VariantGrams,
                    VariantInventoryQty = p.VariantInventoryQty,
                    VariantPrice = p.VariantPrice
                };
            });

            return new SearchResult
            {
                Overview = new SearchResultOverview { TotalResult = totalResults },
                ResultItems = results.ToList()
            };

        }
    }
}
