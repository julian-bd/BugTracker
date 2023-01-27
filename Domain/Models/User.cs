using Domain.DataStorage;

namespace Domain.Models;

public class User : ReadModel
{
    public string Name { get; private set; }

    public User(string name)
    {
        Name = name;
    }

    public void ChangeName(string newName)
    {
        Name = newName;
    }
}