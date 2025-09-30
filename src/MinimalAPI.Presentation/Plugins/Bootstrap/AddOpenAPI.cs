namespace MinimalAPI.Presentation.Plugins.Bootstrap;

public static class AddOpenAPIPlugin
{
  public static void AddOpenAPI(this Presentation.Bootstrap bootstrap)
  {
    bootstrap.Builder.Services.AddEndpointsApiExplorer();
    bootstrap.Builder.Services.AddOpenApiDocument(config =>
    {
      config.DocumentName = "TodoAPI";
      config.Title = "TodoAPI v1";
      config.Version = "v1";
    });
  }
}