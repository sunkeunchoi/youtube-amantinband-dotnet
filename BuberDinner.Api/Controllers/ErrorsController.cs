// <copyright file="ErrorsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
public class ErrorsController : ControllerBase
{
  [Route("/error")]
  public IActionResult Error()
  {
    var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
    Exception? exception = context?.Error;
    var (statusCode, message) = exception switch
    {
      IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
      _ => (StatusCodes.Status500InternalServerError, "Internal Server Error"),
    };
    return Problem(
      statusCode: statusCode,
      title: message);
  }
}