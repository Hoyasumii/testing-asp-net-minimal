namespace Infra.Http.Controllers;

public class HealthController
{
  public static IResult Run() => TypedResults.Ok(new { data = "Hello World" });
}