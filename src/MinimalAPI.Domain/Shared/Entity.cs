namespace MinimalAPI.Domain.Shared;

public abstract class Entity
{
  public string Id { get; } = Guid.NewGuid().ToString();
  public DateTime CreatedAt { get; } = DateTime.Now;
}
