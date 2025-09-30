using MinimalAPI.Presentation.Controllers;

namespace MinimalAPI.Presentation.Routes;

public static class HealthRoutePlugin
{
  public static void HealthRoute(this BootstrapApplication app)
  {
    app.App.MapGet("/", HealthController.Run);
    app.App.MapGet("/hello-world", HealthController.Run);
  }
}