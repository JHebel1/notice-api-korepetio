using Notices.Model.Requests.Notice;
using Notices.Model.Responses.Notice;

namespace Notices.Application.Services;

public interface INoticeService
{
    Task<NoticeResponse> GetNoticeById(Guid id, CancellationToken token);
    Task<Guid> CreateNotice(NoticeRequest request, CancellationToken token);
}