namespace GRS.Model.Forum;

public class Comment
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid ThreadId { get; set; }
    public Guid CreatorId { get; set; }
    public string Content { get; set; }
}