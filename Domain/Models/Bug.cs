namespace Domain.Models;

public class Bug
{
    private readonly List<User> _users;
    private readonly Guid _id;

    public IEnumerable<User> Users => _users;
    public bool IsOpen { get; private set; }

    public string Description { get; }

    public string Title { get; }


    public Bug(string title, string description)
    {
        Title = title;
        Description = description;
        _id = Guid.NewGuid();
        IsOpen = true;
        _users = new List<User>();
    }

    public void Close()
    {
        IsOpen = false;
    }

    public void AssignToUser(User user)
    {
        _users.Add(user);
    }
}