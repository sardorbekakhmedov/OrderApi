using OrderApi.Entities;
using OrderApi.Entities.PaginationEntities;
using OrderApi.Managers;
using OrderApi.Managers.Interfaces;
using OrderApi.Repositories;
using OrderApi.Repositories.Interfaces;
using OrderApi.Services;

namespace OrderApi.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IUserManager, UserManager>();  
        services.AddScoped<IProductManager, ProductManager>(); 
        services.AddScoped<ICategoryManager, CategoryManager>();
        services.AddScoped<IOrderManager, OrderManager>();
        services.AddScoped<ITokenManager<User>, JwtTokenManger>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<FileServices>();
        services.AddScoped<HttpContextHelper>();
    }
}