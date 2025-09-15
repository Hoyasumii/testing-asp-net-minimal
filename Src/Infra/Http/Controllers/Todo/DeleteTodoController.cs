namespace Src.Infra.Http.Controllers.Todo;

using Application.Repositories;
using Domain.Entities;

public class DeleteTodoController
{
  public static async Task<IResult> Run(int id, TodoDb db)
  {
    Todo? targetTodo = await db.Todos.FindAsync(id);

    if (targetTodo is null) return TypedResults.NotFound();

    db.Todos.Remove(targetTodo);
    await db.SaveChangesAsync();

    return TypedResults.NoContent(); 
  }
}