using Api.Infrastructure;
using Api.Models;
using Api.Models.DTOs;

namespace Api.Repositories;

[ExcludeFromCodeCoverage]
public class ToolsData(AppDbContext context, IMapper mapper) : IToolsData
{
    public async Task<ToolsDTO> CreateAsync(ToolsEntity entity, CancellationToken cancellationToken)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ToolsDTO>(entity);
    }
}