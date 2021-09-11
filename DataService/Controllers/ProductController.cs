using System;
using System.Collections.Generic;
using System.Text;
using DataService.Domain.Products;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductCacheUpdater productCacheUpdater;
        private readonly IProductCache productCache;

        public ProductController(
            IProductCacheUpdater productCacheUpdater,
            IProductCache productCache)
        {
            this.productCacheUpdater = productCacheUpdater;
            this.productCache = productCache;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = productCache.GetReferenceForAll();

            return Ok(products);
        }
        
        [HttpPut]
        public IActionResult UpdateProducts([FromBody] InputProductData inputProductData)
        {
            productCacheUpdater.Update(inputProductData.Products);

            return Ok();
        }
    }
}
