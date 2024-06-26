using Api.Models;
using Api.Models.DTOs;

namespace Api.Repositories;

public interface IToolsData
{
    Task<ToolsDTO> CreateAsync(ToolsEntity entity, CancellationToken cancellationToken);
}