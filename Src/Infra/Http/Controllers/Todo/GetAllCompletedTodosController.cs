namespace Src.Infra.Http.Controllers.Todo;

using Src.Domain.Entities;
using Src.Application.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetAllCompletedTodosController
{
  public static async Task<IResult> Run(TodoDb db)
  {
    List<Todo>? allCompletedTodos = await db.Todos.Where(todo => todo.IsComplete).ToListAsync();

    return TypedResults.Ok(allCompletedTodos);
  }
}
