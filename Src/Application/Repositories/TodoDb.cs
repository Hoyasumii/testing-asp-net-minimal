namespace Src.Application.Repositories;

using Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}