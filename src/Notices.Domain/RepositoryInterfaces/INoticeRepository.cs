using Notices.Domain.Entities;

namespace Notices.Domain.RepositoryInterfaces;

public interface INoticeRepository
{
    Task<Notice> GetNoticeById(Guid id, CancellationToken token);
    Task<Guid> AddAsync(Notice notice, CancellationToken token);
}