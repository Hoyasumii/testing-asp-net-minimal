using dotenv.net;
using MinimalAPI.Presentation.Exceptions;

namespace MinimalAPI.Presentation.Plugins.Bootstrap;

public static class LoadEnvPlugin
{
  public static void LoadEnv(this Presentation.Bootstrap bootstrap, string path = "../../.env")
  {
    DotEnvOptions envOptions = new(envFilePaths: [path]);

    DotEnv.Load(envOptions);

    bool isPortExistsAtEnvFile = int.TryParse(Environment.GetEnvironmentVariable("PORT"), out int port);

    if (!isPortExistsAtEnvFile) throw new InvalidEnvFile();

    bootstrap.Builder.WebHost.UseUrls($"http://localhost:{port}");
  }
}