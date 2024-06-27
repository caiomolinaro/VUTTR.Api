using Api.Models;
using Api.Models.DTOs;
using Api.Shared.Infrastructure;

namespace Api.Repositories;

public class ToolsData(AppDbContext context, IMapper mapper) : IToolsData
{
    public async Task<ToolsDTO> CreateAsync(ToolsEntity entity, CancellationToken cancellationToken)
    {
        await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return mapper.Map<ToolsDTO>(entity);
    }

    public async Task<ToolsEntity> DeleteAsync(ToolsEntity entity, CancellationToken cancellationToken)
    {
        context.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<ToolsEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Tools.ToListAsync(cancellationToken);
    }

    public async Task<ToolsEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Tools.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<ToolsEntity>> GetByTagAsync(string tag, CancellationToken cancellationToken)
    {
        return await context.Tools.Where(x => x.Tags.Contains(tag)).ToListAsync(cancellationToken);
    }
}