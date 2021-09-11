using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace DataService.Domain.Products
{
    public interface IProductCache
    {
        ImmutableArray<Product> GetReferenceForAll();
        void SetReferenceForAll(ImmutableArray<Product> products);
    }

    public class ProductCache : IProductCache
    {
        private ImmutableArray<Product> cachedProducts = ImmutableArray<Product>.Empty;

        public ImmutableArray<Product> GetReferenceForAll()
        {
            return cachedProducts;
        }

        public void SetReferenceForAll(ImmutableArray<Product> products)
        {
            cachedProducts = products;
        }
    }
}
