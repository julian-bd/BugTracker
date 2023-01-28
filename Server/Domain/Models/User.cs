using Domain.DataStorage;

namespace Domain.Models;

public class User : IReadModel
{

    public Guid Id { get; set; }
    public string Name { get; private set; }

    public User(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public void ChangeName(string newName)
    {
        Name = newName;
    }
}