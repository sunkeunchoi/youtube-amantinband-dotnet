using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middleware;
public class ErrorHandlingMiddleware
{
  private readonly RequestDelegate _next;
  public ErrorHandlingMiddleware(RequestDelegate next)
  {
    _next = next;
  }
  private static Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    var code = HttpStatusCode.InternalServerError; // 500 if unexpected
    var result = JsonSerializer.Serialize(new { error = exception.Message });
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = (int)code;
    return context.Response.WriteAsync(result);
  }
  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception ex)
    {
      await HandleExceptionAsync(context, ex);
    }
  }


}