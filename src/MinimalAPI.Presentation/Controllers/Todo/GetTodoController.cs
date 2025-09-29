namespace MinimalAPI.Presentation.Controllers.Todo;

using Domain.Todo;
using Microsoft.AspNetCore.Http;
using MinimalAPI.Infra.Abstractions;

public class GetTodoController
{
  public static async Task<IResult> Run(int id, TodoDb db)
  {
    Todo? response = await db.Todos.FindAsync(id);

    if (response is null) return TypedResults.NotFound();

    return TypedResults.Ok(response);
  }
}
