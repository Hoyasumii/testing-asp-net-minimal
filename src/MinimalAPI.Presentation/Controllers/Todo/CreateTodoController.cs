namespace MinimalAPI.Presentation.Controllers.Todo;

using Microsoft.AspNetCore.Http;
using MinimalAPI.Infra.Abstractions;
using MinimalAPI.Domain.Todo;

public class CreateTodoController
{
  public static async Task<IResult> Run(Todo todo, TodoDb db)
  {
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/todo/{todo.Id}", todo);
  }
}
