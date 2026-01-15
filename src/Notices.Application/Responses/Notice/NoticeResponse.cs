
namespace Notices.Application.Responses.Notice;

public class NoticeResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid OwnerId { get; set; }
    public List<OfferDto> Offers { get; set; }
    public SubjectDto Subject { get; set; }
}