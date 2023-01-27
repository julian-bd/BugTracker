namespace Domain.Models;

public class ReadModel
{
    public readonly Guid Id;

    protected ReadModel()
    {
        Id = Guid.NewGuid();
    }
}