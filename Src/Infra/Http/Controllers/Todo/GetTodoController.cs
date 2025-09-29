namespace Infra.Http.Controllers.Todo;

using Application.Repositories;
using Domain.Todo;

public class GetTodoController
{
  public static async Task<IResult> Run(int id, TodoDb db)
  {
    Todo? response = await db.Todos.FindAsync(id);

    if (response is null) return TypedResults.NotFound();

    return TypedResults.Ok(response);
  }
}
