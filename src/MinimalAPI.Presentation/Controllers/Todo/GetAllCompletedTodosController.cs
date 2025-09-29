namespace MinimalAPI.Presentation.Controllers.Todo;

using Domain.Todo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Infra.Abstractions;

public class GetAllCompletedTodosController
{
  public static async Task<IResult> Run(TodoDb db)
  {
    List<Todo>? allCompletedTodos = await db.Todos.Where(todo => todo.IsComplete).ToListAsync();

    return TypedResults.Ok(allCompletedTodos);
  }
}
