namespace MinimalAPI.Presentation;

using Microsoft.EntityFrameworkCore;
using MinimalAPI.Infra;
using MinimalAPI.Presentation.Plugins.Bootstrap;

public class Bootstrap
{
  public WebApplicationBuilder Builder { get; } = WebApplication.CreateBuilder();

  public static Bootstrap Make()
  {
    var bootstrap = new Bootstrap();

    // Isso aqui é só pra validar um ponto
    bootstrap.Builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

    bootstrap.LoadEnv();
    bootstrap.AddCors();
    bootstrap.AddOpenAPI();

    return bootstrap;
  }

}
