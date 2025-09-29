namespace MinimalAPI.Presentation.Routes;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using MinimalAPI.Infra.Http.Controllers.Todo;

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
