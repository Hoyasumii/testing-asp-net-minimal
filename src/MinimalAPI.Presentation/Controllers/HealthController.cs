namespace MinimalAPI.Presentation.Controllers;

public class HealthController
{
  public static IResult Run() => Results.Ok(new { data = "Hello World" });
}
