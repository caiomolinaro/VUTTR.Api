using Api.Models.DTOs;

namespace Api.Models;

public class ToolsValidator : AbstractValidator<ToolsDTO>
{
    public ToolsValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty");

        RuleFor(x => x.Link)
            .NotEmpty()
            .WithMessage("Link cannot be empty");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description cannot be empty");

        RuleFor(x => x.Tags)
            .NotEmpty()
            .WithMessage("Tags cannot be empty");
    }
}