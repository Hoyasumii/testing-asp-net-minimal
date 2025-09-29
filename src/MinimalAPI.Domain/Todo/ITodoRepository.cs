namespace MinimalAPI.Domain.Todo;

public interface ITodoRepository
{
  Task<Todo> Create(string name);
  Task<Todo> GetById(string id);
  Task<List<Todo>> GetAllCompleted();
  Task<List<Todo>> GetAll();
  Task<Todo> Update(string id, string? name, bool? isCompleted);
  Task Delete(string id);
}