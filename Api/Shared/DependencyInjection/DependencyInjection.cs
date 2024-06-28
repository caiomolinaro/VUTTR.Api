using Api.Repositories;
using Api.Shared.Infrastructure;
using Api.Shared.Middlewares;

namespace Api.Shared.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));
        services.AddScoped<IToolsData, ToolsData>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        return services;
    }

    public static IServiceCollection AddDependencyInjectionValidator(this IServiceCollection services, IApplicationBuilder app)
    {
        app.UseMiddleware<FluentValidationExceptionHandler>();

        return services;
    }
}