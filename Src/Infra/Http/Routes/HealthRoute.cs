using Infra.Http.Controllers;

namespace Infra.Http.Routes;

public class HealthRoute
{
  public static void Build(WebApplication app)
  {
    app.MapGet("/", HealthController.Run);
    app.MapGet("/hello-world", HealthController.Run);
  }
}