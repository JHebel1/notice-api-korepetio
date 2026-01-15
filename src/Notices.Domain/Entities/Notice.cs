namespace Notices.Domain.Entities;

public class Notice
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public Guid OwnerId { get; private set; }
    public Subject Subject { get; private set; }
    public List<Offer> Offers { get; private set; }
}
