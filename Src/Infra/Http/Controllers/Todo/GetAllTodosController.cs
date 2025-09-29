namespace Infra.Http.Controllers.Todo;

using Domain.Todo;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetAllTodosController
{
  public static async Task<IResult> Run(TodoDb db)
  {
    List<Todo> response = await db.Todos.ToListAsync();
    return TypedResults.Ok(response);
  }
}

// TODO: Criar melhor esse repositório