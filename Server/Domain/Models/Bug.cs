namespace Domain.Models;

public class Bug : IReadModel
{
    private readonly List<Guid> _users;
    public Guid Id { get; set; }
    public IEnumerable<Guid> Users => _users;
    public bool IsOpen { get; private set; }

    public string Description { get; }

    public string Title { get; }


    public Bug(string title, string description)
    {
        Title = title;
        Description = description;
        IsOpen = true;
        _users = new List<Guid>();
        Id = Guid.NewGuid();
    }

    public void Close()
    {
        IsOpen = false;
    }

    public void AssignToUser(Guid user)
    {
        _users.Add(user);
    }
}