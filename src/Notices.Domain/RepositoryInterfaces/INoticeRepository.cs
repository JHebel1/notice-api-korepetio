using Notices.Domain.Entities;

namespace Notices.Domain.RepositoryInterfaces;

public interface INoticeRepository
{
    Task<Notice> GetNoticeById(Guid id, CancellationToken token);
    Task<Guid> GetNoticeOwnerIdByNoticeId(Guid noticeId, CancellationToken token);
    Task<Guid> AddAsync(Notice notice, CancellationToken token);
    Task<bool> DeleteAsync(Guid id, CancellationToken token);
    Task<bool> SetStatusDeleted(Guid id, CancellationToken token);
    Task<Notice> RenewNotice(Guid id, CancellationToken token, int extendDays = 30);
    Task <List<Notice>> GetAllNotices(int page, int pageSize, CancellationToken token);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}