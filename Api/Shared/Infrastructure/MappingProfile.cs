using Api.Models;
using Api.Models.DTOs;

namespace Api.Shared.Infrastructure;

[ExcludeFromCodeCoverage]
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ToolsDTO, ToolsEntity>();
        CreateMap<ToolsEntity, ToolsDTO>();
    }
}