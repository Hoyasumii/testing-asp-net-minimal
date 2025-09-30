using MinimalAPI.Presentation.Controllers.Todo;

namespace MinimalAPI.Presentation.Routes;

public class TodoRoute
{
  public static void Build(WebApplication app)
  {
    RouteGroupBuilder group = app.MapGroup("/todo");

    group.MapGet("/", GetAllTodosController.Run);
    group.MapGet("/{id:int}", GetTodoController.Run);
    group.MapGet("/complete", GetAllCompletedTodosController.Run);
    group.MapPost("/", CreateTodoController.Run);
    group.MapPut("/{id:int}", UpdateTodoController.Run);
    group.MapDelete("/{id:int}", DeleteTodoController.Run);
  }
}
