namespace MinimalAPI.Infra.Abstractions;

using MinimalAPI.Domain.Todo;
using Microsoft.EntityFrameworkCore;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}