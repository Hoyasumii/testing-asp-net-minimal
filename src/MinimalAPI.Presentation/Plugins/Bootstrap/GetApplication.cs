namespace MinimalAPI.Presentation.Plugins.Bootstrap;

public static class GetApplicationPlugin
{
  public static BootstrapApplication GetApplication(this Presentation.Bootstrap bootstrap)
  {
    return new BootstrapApplication
    {
      App = bootstrap.Builder.Build()
    };
  }
}
