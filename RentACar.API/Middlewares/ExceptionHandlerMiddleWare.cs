using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

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
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = ex.Message,
                Title = "Something went wrong!"
            }));
        }
    }
}