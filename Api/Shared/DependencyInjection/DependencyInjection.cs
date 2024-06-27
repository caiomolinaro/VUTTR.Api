using Api.Repositories;
using Api.Shared.Infrastructure;

namespace Api.Shared.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IToolsData, ToolsData>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));

        return services;
    }
}