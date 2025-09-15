namespace Src.Infra.Http.Routes;

using Src.Infra.Http.Controllers.Todo;

public class TodoRoute
{
  public static void build(WebApplication app)
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
