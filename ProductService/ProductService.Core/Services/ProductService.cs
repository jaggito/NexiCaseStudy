using ProductService.Core.Entities;
using ProductService.Core.Interfaces;

namespace ProductService.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

}
