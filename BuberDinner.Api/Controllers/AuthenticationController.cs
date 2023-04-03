// <copyright file="AuthenticationController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Api.Controller;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;

using ErrorOr;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public AuthenticationController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = _mapper.Map<RegisterCommand>(request);
    ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
    return registerResult.Match(
      authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
      errors => Problem(errors));
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var query = _mapper.Map<LoginQuery>(request);
    var authResult = await _mediator.Send(query);
    return authResult.Match(
      authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
      errors => Problem(errors));
  }
}