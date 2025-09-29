using Microsoft.AspNetCore.Builder;
using MinimalAPI.Infra.Http.Controllers;

namespace MinimalAPI.Presentation.Routes;

public class HealthRoute
{
  public static void Build(WebApplication app)
  {
    app.MapGet("/", HealthController.Run);
    app.MapGet("/hello-world", HealthController.Run);
  }
}