using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure;
using ProductService.Infrastructure.Data;

namespace ProductService.API;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<ProductDbContext>(options =>
            options.UseInMemoryDatabase("ProductDb")); // Use a real database in production

        services.AddProductServiceDependencies();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
