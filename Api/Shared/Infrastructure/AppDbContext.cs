using Api.Models;

namespace Api.Shared.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<ToolsEntity> Tools { get; set; }
}