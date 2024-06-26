using Api.Models;
using Api.Models.DTOs;

namespace Api.Repositories;

public interface IToolsData
{
    Task<ToolsDTO> CreateAsync(ToolsEntity entity, CancellationToken cancellationToken);

    Task<IEnumerable<ToolsEntity>> GetAllAsync(CancellationToken cancellationToken);

    Task<IEnumerable<ToolsEntity>> GetByTagAsync(string tag, CancellationToken cancellationToken);

    Task<ToolsEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<ToolsEntity> DeleteAsync(ToolsEntity entity, CancellationToken cancellationToken);
}