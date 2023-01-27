namespace Domain.Models;

public class Bug : ReadModel
{
    private readonly List<Guid> _users;
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