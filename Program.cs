using Microsoft.EntityFrameworkCore;
using dotenv.net;

using Minimal.Application.Repositories;
using Minimal.Domain.Entities;

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

app.MapGet("/", (ILogger<Program> logger) => TypedResults.Ok(new { data = "Hello World" }));

RouteGroupBuilder todoGroup = app.MapGroup("/todo");

todoGroup.MapGet("/", GetTodos);
todoGroup.MapGet("/{id}", GetTargetTodo);
todoGroup.MapGet("/complete", GetAllCompletedTodos);
todoGroup.MapPost("/", CreateTodo);
todoGroup.MapPut("/{id}", UpdateTodo);
todoGroup.MapDelete("/{id}", DeleteTodo);

app.Run();

static async Task<IResult> GetTodos(TodoDb db)
{
  return TypedResults.Ok(await db.Todos.ToListAsync());
}

static async Task<IResult> GetTargetTodo(int id, TodoDb db)
{
  Todo? response = await db.Todos.FindAsync(id);

  if (response is null) return TypedResults.NotFound();

  return TypedResults.Ok(response);
}

static async Task<IResult> GetAllCompletedTodos(TodoDb db)
{
  List<Todo>? response = await db.Todos.Where(todo => todo.IsComplete).ToListAsync();

  return TypedResults.Ok(response);
}

static async Task<IResult> CreateTodo(Todo todo, TodoDb db)
{
  db.Todos.Add(todo);
  await db.SaveChangesAsync();

  return TypedResults.Created($"/todo/${todo.Id}", todo);
}

static async Task<IResult> UpdateTodo(int id, Todo todo, TodoDb db)
{
  Todo? response = await db.Todos.FindAsync(id);

  if (response is null) return TypedResults.NotFound();

  response.Name = todo.Name;
  response.IsComplete = todo.IsComplete;

  await db.SaveChangesAsync();

  return TypedResults.Ok(response);
}

static async Task<IResult> DeleteTodo(int id, TodoDb db)
{
  Todo? targetTodo = await db.Todos.FindAsync(id);

  if (targetTodo is null) return TypedResults.NotFound();

  db.Todos.Remove(targetTodo);
  await db.SaveChangesAsync();
  return TypedResults.NoContent();
}
