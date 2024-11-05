using ProductService.Core.Entities;

namespace ProductService.Core.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(Guid id);
    // Other CRUD operations
}
