
using AutoMapper;
using Notices.Domain.Entities;
using Notices.Domain.RepositoryInterfaces;
using Notices.Model.Requests.Notice;
using Notices.Model.Responses.Notice;

namespace Notices.Application.Services;

public class NoticeService(INoticeRepository noticeRepository, IMapper mapper) : INoticeService
{
    public async Task<NoticeResponse> GetNoticeById(Guid id, CancellationToken token)
    {
        var notice = await noticeRepository.GetNoticeById(id,  token);
        return mapper.Map<NoticeResponse>(notice);
    }

    public async Task<Guid> CreateNotice(NoticeRequest request, CancellationToken token)
    {
        var notice = mapper.Map<Notice>(request);
        return await noticeRepository.AddAsync(notice, token);
    }
}