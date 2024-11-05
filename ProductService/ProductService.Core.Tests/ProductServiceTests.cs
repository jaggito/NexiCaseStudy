using ProductService.Core.Entities;
using ProductService.Core.Interfaces;

namespace ProductService.Core.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepository;
    private readonly Core.Services.ProductService _productService;

    public ProductServiceTests()
    {
        _mockRepository = new Mock<IProductRepository>();
        _productService = new Core.Services.ProductService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetProductsAsync_ReturnsListOfProducts()
    {
        // Arrange
        var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Product 1", Description = "Description 1" },
                new Product { Id = Guid.NewGuid(), Name = "Product 2", Description = "Description 2" },
            };

        _mockRepository.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(products);

        // Act
        var result = await _productService.GetProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, ((List<Product>)result).Count);
        _mockRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetProductAsync_ReturnsProduct_WhenProductExists()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product { Id = productId, Name = "Product 1", Description = "Description 1" };

        _mockRepository.Setup(repo => repo.GetByIdAsync(productId))
            .ReturnsAsync(product);

        // Act
        var result = await _productService.GetProductAsync(productId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(productId, result.Id);
        _mockRepository.Verify(repo => repo.GetByIdAsync(productId), Times.Once);
    }

    [Fact]
    public async Task GetProductAsync_ReturnsNull_WhenProductDoesNotExist()
    {
        // Arrange
        var productId = Guid.NewGuid();

        _mockRepository.Setup(repo => repo.GetByIdAsync(productId))
            .ReturnsAsync((Product)null);

        // Act
        var result = await _productService.GetProductAsync(productId);

        // Assert
        Assert.Null(result);
        _mockRepository.Verify(repo => repo.GetByIdAsync(productId), Times.Once);
    }
}