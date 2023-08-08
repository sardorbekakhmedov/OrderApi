using Microsoft.EntityFrameworkCore;
using OrderApi.Context;

namespace OrderApi.Extensions;

public static partial  class ServiceCollectionExtensions
{
    public static void AddOrderApiDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch(switchName: "Npgsql.EnableLegacyTimestampBehavior", isEnabled: true);
        services.AddDbContext<AppDbContext>(config =>
        {
            config.UseSnakeCaseNamingConvention()
                //.UseInMemoryDatabase("OrderDb");
              .UseNpgsql(configuration.GetConnectionString("OrderDb"));
        });
    }
}