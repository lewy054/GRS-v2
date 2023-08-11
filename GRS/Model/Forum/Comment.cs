namespace GRS.Model.Forum;

public class Comment
{
    public Guid Id { get; } = Guid.NewGuid();
    public Thread Thread { get; set; }
    public User.User User { get; set; }
    public string Content { get; set; }
    
}