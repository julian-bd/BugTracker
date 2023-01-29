namespace Domain.Models;

public class Bug : IReadModel
{
    private List<Guid> _users;
    public Guid Id { get; set; }
    public IEnumerable<Guid> Users => _users;
    public bool IsOpen { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public string Title { get; set; }

    public Bug(string title, string description)
    {
        Title = title;
        Description = description;
        IsOpen = true;
        _users = new List<Guid>();
        Id = Guid.NewGuid();
        DateCreated = DateTime.UtcNow;
    }

    public void Close()
    {
        IsOpen = false;
    }

    public void AssignToUser(Guid user)
    {
        if (_users is null)
        {
            _users = new List<Guid>();
        }
        
        _users.Add(user);
    }
}