using Notices.Domain.Entities;

namespace Notices.Domain.RepositoryInterfaces;

public interface INoticeRepository
{
    Task<Notice> GetNoticeById(Guid id, CancellationToken token);
    Task<Guid> GetNoticeOwnerIdByNoticeId(Guid noticeId, CancellationToken token);
    Task<Guid> AddAsync(Notice notice, CancellationToken token);
    Task<bool> DeleteAsync(Guid id, CancellationToken token);
    Task <List<Notice>> GetAllNotices(int page, int pageSize, CancellationToken token);
}