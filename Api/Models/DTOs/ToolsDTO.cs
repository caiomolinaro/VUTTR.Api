namespace Api.Models.DTOs;

public record ToolsDTO(string? Title, string? Link, string? Description, List<string>? Tags);