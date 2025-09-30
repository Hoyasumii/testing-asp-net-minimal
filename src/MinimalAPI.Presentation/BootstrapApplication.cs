namespace MinimalAPI.Presentation;

public class BootstrapApplication
{
  public required WebApplication App { get; init; }

  public void Run()
  {
    App.Run();
  }
}