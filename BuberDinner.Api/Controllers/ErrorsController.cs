using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
public class ErrorsController : ControllerBase
{
  [Route("/error")]
  public IActionResult Error()
  {
    var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
    if (context?.Error is not null)
    {
      return Problem(
        title: context.Error.Message
      );
    }
    return Problem(
    );
  }
}