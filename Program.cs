using Microsoft.EntityFrameworkCore;
using dotenv.net;

using Src.Application.Repositories;
using Src.Infra.Http.Routes;

DotEnv.Load();

int.TryParse(Environment.GetEnvironmentVariable("PORT") ?? "3000", out int PORT);

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
  config.DocumentName = "TodoAPI";
  config.Title = "TodoAPI v1";
  config.Version = "v1";
});

WebApplication app = builder.Build();
app.Urls.Add($"http://localhost:{PORT}");

if (app.Environment.IsDevelopment())
{
  app.UseOpenApi();
  app.UseSwaggerUi(config =>
  {
    config.DocumentTitle = "TodoAPI";
    config.Path = "/docs";
    config.DocumentPath = "/swagger/{documentName}/swagger.json";
    config.DocExpansion = "list";
  });
}

HealthRoute.build(app);
TodoRoute.build(app);

app.Run();
