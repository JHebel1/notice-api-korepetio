namespace Notices.Domain.Entities;

public class Notice
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
