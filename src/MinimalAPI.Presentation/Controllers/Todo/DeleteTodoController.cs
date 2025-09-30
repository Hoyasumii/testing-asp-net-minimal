namespace MinimalAPI.Presentation.Controllers.Todo;

using Domain.Todo;
using Microsoft.AspNetCore.Http;
using MinimalAPI.Infra;

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