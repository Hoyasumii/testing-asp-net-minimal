namespace Src.Domain.Todo;

public class Todo
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public string Name { get; protected set; }
  public bool IsComplete { get; set; } = false;

  public Todo(string name)
  {
    Name = name;
  } 
}