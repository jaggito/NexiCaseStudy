using ProductService.Core.Entities;

namespace ProductService.Core.Interfaces;
public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(Guid id);
    // Other business operations
}
