namespace Domain.Todo;

public class Todo(string name)
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public string Name { get; protected set; } = name;
  public bool IsComplete { get; set; } = false;
  public DateTime CreatedAt { get; } = DateTime.Now;
}