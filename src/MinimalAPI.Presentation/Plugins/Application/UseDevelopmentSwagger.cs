namespace MinimalAPI.Presentation.Plugins.Application;

public static class UseDevelopmentSwaggerPlugin
{
  public static void UseDevelopmentSwagger(this BootstrapApplication bootstrap)
  {
    if (bootstrap.App.Environment.IsDevelopment())
    {
      bootstrap.App.UseOpenApi();
      bootstrap.App.UseSwaggerUi(config =>
      {
        config.DocumentTitle = "TodoAPI";
        config.Path = "/docs";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
      });
    }
  }
}