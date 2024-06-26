namespace Api.Models.DTOs;

[ExcludeFromCodeCoverage]
public class ToolsDTO
{
    public string? Title { get; set; }
    public string? Link { get; set; }
    public string? Description { get; set; }
    public List<string>? Tags { get; set; }
}