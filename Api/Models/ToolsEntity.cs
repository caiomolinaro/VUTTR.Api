namespace Api.Models;

[ExcludeFromCodeCoverage]
public class ToolsEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Title { get; set; }
    public string? Link { get; set; }
    public string? Description { get; set; }
    public List<string>? Tags { get; set; }
}