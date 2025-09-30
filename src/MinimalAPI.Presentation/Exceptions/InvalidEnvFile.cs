namespace MinimalAPI.Presentation.Exceptions;

public class InvalidEnvFile : Exception
{
  public InvalidEnvFile() : base("Algumas Propriedades desejadas no .env não estão presentes") { }
}