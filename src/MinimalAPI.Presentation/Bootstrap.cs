namespace MinimalAPI.Presentation;

using dotenv.net;

public class Bootstrap
{
  WebApplication App { get; }

  public Bootstrap(string path = "../../.env")
  {
    DotEnvOptions envOptions = new(envFilePaths: [path]);

    DotEnv.Load(envOptions);

    WebApplicationBuilder builder = WebApplication.CreateBuilder();

    builder.Services.AddCors();
    

    App = builder.Build();
  }
}
