using BlazorShop.Server.BusinessLogic;
using BlazorShop.Shared.Models;
using BlazorShop.Shared.Models.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;
        private ILogger<ProductController> logger;
        public ProductController(IProductManager productManager, ILogger<ProductController> logger)
        {
            this.productManager = productManager;
            this.logger = logger;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await productManager.GetAllProducts();
            return new OkObjectResult(result);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<SearchResult>> Search(SearchRequest searchRequest)
        {
            logger.LogInformation("SearchRequest: ", searchRequest);
            try
            {
                var result = await productManager.SearchProducts(searchRequest);
                return new OkObjectResult(result);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var result = await productManager.GetProduct(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
