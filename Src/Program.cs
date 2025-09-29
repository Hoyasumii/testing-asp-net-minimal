using Microsoft.EntityFrameworkCore;
using dotenv.net;

using Application.Repositories;
using Infra.Http.Routes;

DotEnv.Load();

bool envPortIsParsed = int.TryParse(Environment.GetEnvironmentVariable("PORT") ?? "3000", out int PORT);

if (!envPortIsParsed)
{
  Environment.Exit(1);
}

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

HealthRoute.Build(app);
TodoRoute.Build(app);

app.Run($"http://localhost:{PORT}");
