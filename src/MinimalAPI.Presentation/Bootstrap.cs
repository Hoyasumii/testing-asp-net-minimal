namespace MinimalAPI.Presentation;

using MinimalAPI.Presentation.Plugins.Bootstrap;

public class Bootstrap
{
  public WebApplicationBuilder Builder { get; } = WebApplication.CreateBuilder();

  public static Bootstrap Make()
  {
    var bootstrap = new Bootstrap();

    bootstrap.AddDatabaseContext();
    bootstrap.LoadEnv();
    bootstrap.AddCors();
    bootstrap.AddOpenAPI();

    return bootstrap;
  }

}
