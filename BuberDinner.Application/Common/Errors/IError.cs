using System.Net;

namespace BuberDinner.Application.Common.Errors
{
  public class IError
  {
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; } = null!;
  }
}