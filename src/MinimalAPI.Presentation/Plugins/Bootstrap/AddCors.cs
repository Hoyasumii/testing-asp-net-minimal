namespace MinimalAPI.Presentation.Plugins.Bootstrap;

public static class AddCorsPlugin
{
  public static void AddCors(this Presentation.Bootstrap bootstrap)
  {
    bootstrap.Builder.Services.AddCors();
  }
}