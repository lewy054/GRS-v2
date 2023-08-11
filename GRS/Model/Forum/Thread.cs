using GRS.Model.User;

namespace GRS.Model.Forum;

public class Thread
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime StartDate { get;  } = DateTime.UtcNow;
    public bool Closed { get; set; } = false;
    
    public User.User Author { get; set; }
    public ICollection<Comment> Comment { get; set; } = new List<Comment>();
    
}