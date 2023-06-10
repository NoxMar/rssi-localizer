namespace Application.Contracts;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(object key, Exception cause) 
        : base($"Entity could not be retrieved for key '{key}'", cause)
    {
    }

    public EntityNotFoundException(object key) : base($"Entity could not be retrieved for key '{key}'")
    {
    }
}