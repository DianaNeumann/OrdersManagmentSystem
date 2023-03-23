namespace Infrastructure.Common;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string? message)
        : base(message) { }

    public static EntityNotFoundException For<T>(Guid id)
    {
        return new EntityNotFoundException($"Entity of type {typeof(T).Name} with id {id} was not found");
    }
}