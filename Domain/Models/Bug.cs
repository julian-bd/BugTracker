using Domain.DataStorage;

namespace Domain.Models;

public class Bug : ReadModel
{
    private readonly List<User> _users;
    public IEnumerable<User> Users => _users;
    public bool IsOpen { get; private set; }

    public string Description { get; }

    public string Title { get; }


    public Bug(string title, string description) 
    {
        Title = title;
        Description = description;
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