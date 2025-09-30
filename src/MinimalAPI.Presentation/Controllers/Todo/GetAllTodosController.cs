namespace MinimalAPI.Presentation.Controllers.Todo;

using Domain.Todo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Infra;

public class GetAllTodosController
{
  public static async Task<IResult> Run(TodoDb db)
  {
    List<Todo> response = await db.Todos.ToListAsync();
    return TypedResults.Ok(response);
  }
}

// TODO: Criar melhor esse repositório