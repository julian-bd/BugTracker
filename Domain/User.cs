namespace Domain;

public class User
{
    private readonly Guid _id;

    public string Name { get; private set; }

    public User(string name)
    {
        Name = name;
        _id = Guid.NewGuid();
    }

    public void ChangeName(string newName)
    {
        Name = newName;
    }
}