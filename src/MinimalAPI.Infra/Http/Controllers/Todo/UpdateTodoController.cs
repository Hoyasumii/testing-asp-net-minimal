namespace MinimalAPI.Infra.Http.Controllers.Todo;

using Microsoft.AspNetCore.Http;
using MinimalAPI.Domain.Todo;
using MinimalAPI.Infra.Abstractions;

public class UpdateTodoController
{
  public async static Task<IResult> Run(int id, Todo todo, TodoDb db)
  {
    Todo? targetTodo = await db.Todos.FindAsync(id);

    if (targetTodo is null) return TypedResults.NotFound();

    targetTodo.IsComplete = todo.IsComplete;
    targetTodo.Name = todo.Name;

    await db.SaveChangesAsync();

    return TypedResults.Ok(targetTodo);
  }
}