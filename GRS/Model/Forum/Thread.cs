namespace GRS.Model.Forum;

public class Thread
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Content { get; set; }
    string Section { get; set; }
    public DateTime StartDate { get; set; }
    public bool Closed { get; set; } = false;
    
    public string UserId { get; set; }
    // public ApplicationUser ApplicationUser { get; set; }
    public ICollection<Comment> Comment { get; set; }
}