using GRS.Model.Forum;
using Thread = GRS.Model.Forum.Thread;

namespace GRS.Model.User;

public class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public List<Role> Roles { get; set; } //= new();
    public List<Thread> Threads { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();

    public User(string userName, string passwordHash, string email)
    {
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
        //TODO: DELETE
        Roles = new List<Role>
        {
            new() { Name = "test" },
            new() { Name = "test1" },
        };
    }
}