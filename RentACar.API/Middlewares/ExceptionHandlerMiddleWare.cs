using System.Net;
using System.Net.Mime;

namespace RentACar.API.Middlewares;

public class ExceptionHandlerMiddleWare
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
                Title = "Something went wrong!"
            });
        }
    }
}