using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DataService.Domain.Products
{
    public interface IProductCacheUpdater
    {
        void Update(Product[] products);
    }

    public class ProductCacheUpdater : IProductCacheUpdater
    {
        private readonly IProductCache productCache;

        public ProductCacheUpdater(IProductCache productCache)
        {
            this.productCache = productCache;
        }

        public void Update(Product[] products)
        {
            productCache.SetReferenceForAll(products.ToImmutableArray());
        }
    }
}
