using Microsoft.EntityFrameworkCore;
using MinimalAPI.Infra;

namespace MinimalAPI.Presentation.Plugins.Bootstrap;

public static class AddDatabaseContextPlugin
{
  public static void AddDatabaseContext(this Presentation.Bootstrap bootstrap)
  {
    bootstrap.Builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
  }
}