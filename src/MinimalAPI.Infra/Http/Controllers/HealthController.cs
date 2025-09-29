using Microsoft.AspNetCore.Http;

namespace MinimalAPI.Infra.Http.Controllers;

public class HealthController
{
  public static IResult Run() => Results.Ok(new { data = "Hello World" });
}
