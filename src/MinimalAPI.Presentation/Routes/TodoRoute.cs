using MinimalAPI.Presentation.Controllers.Todo;
using MinimalAPI.Presentation.Plugins.Bootstrap;

namespace MinimalAPI.Presentation.Routes;

public static class TodoRoutePlugin
{
  public static void TodoRoute(this BootstrapApplication app)
  {
    RouteGroupBuilder group = app.App.MapGroup("/todo");

    group.MapGet("/", GetAllTodosController.Run);
    group.MapGet("/{id:int}", GetTodoController.Run);
    group.MapGet("/complete", GetAllCompletedTodosController.Run);
    group.MapPost("/", CreateTodoController.Run);
    group.MapPut("/{id:int}", UpdateTodoController.Run);
    group.MapDelete("/{id:int}", DeleteTodoController.Run);
  }
}
