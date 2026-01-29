using Microsoft.EntityFrameworkCore;
using Notices.Application.Commands.RenewNotice;
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
            throw new KeyNotFoundException($"Notice with id '{id}' not found.");
        return notice;
    }
    
    public async Task<Guid> GetNoticeOwnerIdByNoticeId(Guid noticeId, CancellationToken token)
    {
        var ownerId = await noticesDbContext.Notices
            .Where(n => n.Id == noticeId)
            .Select(n => n.OwnerId)
            .FirstOrDefaultAsync(token);

        if (ownerId == default)
            throw new KeyNotFoundException($"Notice with id '{noticeId}' not found.");

        return ownerId;
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
            throw new KeyNotFoundException("No notices found");
        return notice;
    }

    public async Task<Notice> RenewNotice(Guid id, CancellationToken token, int extendDays = 30)
    {
        var notice = await noticesDbContext.Notices
            .FirstOrDefaultAsync(n => n.Id == id && n.Status != Status.Deleted, token);

        if (notice is null)
            throw new KeyNotFoundException($"Notice with id '{id}' not found");
        
        notice.renewNotice(extendDays);
        
        await noticesDbContext.SaveChangesAsync(token);
        return notice;
    }
    
    public async Task<bool> DeleteAsync(Guid id, CancellationToken token)
    {
        var notice = await noticesDbContext.Notices.FindAsync(new object[] { id }, token);
        if (notice == null) 
            throw new KeyNotFoundException($"Notice with id '{id}' not found.");

        noticesDbContext.Notices.Remove(notice);
        await noticesDbContext.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> SetStatusDeleted(Guid id, CancellationToken token)
    {
        int affectedRows = await noticesDbContext.Notices
            .Where(n => n.Id == id)
            .ExecuteUpdateAsync(s => s.SetProperty(n => n.Status, Status.Deleted), token);

        if (affectedRows == 0)
            throw new KeyNotFoundException($"Notice with '{id}' not found");
        
        return true;
    }
}
