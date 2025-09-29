using MinimalAPI.Domain.Shared;

namespace MinimalAPI.Domain.Todo;

public class Todo(string name): Entity
{
  public string Name { get; set; } = name;
  public bool IsComplete { get; set; } = false;
}
