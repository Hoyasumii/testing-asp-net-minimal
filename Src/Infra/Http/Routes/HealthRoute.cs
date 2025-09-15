using Src.Infra.Http.Controllers;

public class HealthRoute
{
  public static void build(WebApplication app)
  {
    app.MapGet("/", HealthController.Run);
    app.MapGet("/hello-world", HealthController.Run);
  }
}