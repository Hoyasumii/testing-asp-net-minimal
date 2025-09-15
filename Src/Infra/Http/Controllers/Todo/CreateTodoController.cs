namespace Src.Infra.Http.Controllers.Todo;

using Application.Repositories;
using Domain.Entities;

public class CreateTodoController
{
  public static async Task<IResult> Run(Todo todo, TodoDb db)
  {
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/todo/{todo.Id}", todo);
  }
}
