namespace Infra.Http.Controllers.Todo;

using Application.Repositories;
using Domain.Todo;

public class UpdateTodoController
{
  public async static Task<IResult> Run(int id, Todo todo, TodoDb db)
  {
    Todo? targetTodo = await db.Todos.FindAsync(id);

    if (targetTodo is null) return TypedResults.NotFound();

    targetTodo.IsComplete = todo.IsComplete;

    await db.SaveChangesAsync();

    return TypedResults.Ok(targetTodo);
  }
}