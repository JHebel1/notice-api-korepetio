using Notices.Domain.RepositoryInterfaces;
using Notices.Domain.Entities;
using Notices.Infrastructure.Database;

namespace Notices.Infrastructure.Repositories;

public class NoticeRepository(NoticesDbContext noticesDbContext) : INoticeRepository
{
    public async Task<Notice> GetNoticeById(Guid id, CancellationToken token)
    {
        var notice = await noticesDbContext.Notices.FindAsync(id, token);
        if (notice is null)
            throw new InvalidOperationException($"Notice with id '{id}' not found.");
        return notice;
    }

    public async Task<Guid> AddAsync(Notice notice, CancellationToken token)
    {
        noticesDbContext.Add(notice);
        await noticesDbContext.SaveChangesAsync(token);
        return notice.Id;
    }
}
