namespace Domain.Common;

public class EntityNotFoundException : DomainException
{
    public EntityNotFoundException()
    {
    }

    public EntityNotFoundException(string? message)
        : base(message)
    {
    }
}