// <copyright file="IServiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Net;

namespace BuberDinner.Application.Common.Errors;
public interface IServiceException
{
  public HttpStatusCode StatusCode { get; }

  public string ErrorMessage { get; }
}