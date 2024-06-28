using Api.Shared.Models;

namespace Api.Shared.Middlewares;

public class FluentValidationExceptionHandler
{
    private readonly RequestDelegate _next;
    private const string ContentType = "application/json";

    public FluentValidationExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = ContentType;

            var response = new Response<string>(string.Empty, ex.Message);

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}