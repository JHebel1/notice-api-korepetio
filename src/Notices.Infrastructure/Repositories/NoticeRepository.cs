using Microsoft.EntityFrameworkCore;
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
        noticesDbContext.Notices.Add(notice);
        await noticesDbContext.SaveChangesAsync(token);
        return notice.Id;
    }

    public async Task<List<Notice>> GetAllNotices(int page, int pageSize, CancellationToken token)
    {
        var notice = await noticesDbContext.Notices.Skip((page-1) * pageSize).Take(pageSize).ToListAsync(token);
        if (notice is null)
            throw new InvalidOperationException("No notices found");
        return notice;
    }
}
