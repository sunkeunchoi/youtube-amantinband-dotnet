using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
  public override void OnException(ExceptionContext context)
  {
    var exception = context.Exception;
    context.Result = new ObjectResult(new { error = exception.Message })
    {
      StatusCode = (int)HttpStatusCode.InternalServerError
    };
    context.ExceptionHandled = true;
    // var response = context.HttpContext.Response;
    // response.ContentType = "application/json";
    // response.StatusCode = (int)HttpStatusCode.InternalServerError;
    // var result = JsonSerializer.Serialize(new { error = exception.Message });
    // response.WriteAsync(result);
  }
}