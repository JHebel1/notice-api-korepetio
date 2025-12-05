using AutoMapper;
using MediatR;
using Notices.Application.Responses.Notice;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Queries.GetAllNotices;

public class GetAllNoticeQueryHandler(INoticeRepository noticeRepository, IMapper mapper) : IRequestHandler<GetAllNoticesQuery, List<NoticeResponse>>
{
    public async Task<List<NoticeResponse>> Handle(GetAllNoticesQuery request, CancellationToken cancellationToken)
    {
        var notices = await noticeRepository.GetAllNotices(request.page, request.pageSize, cancellationToken);
        var noticesResponse = mapper.Map<List<NoticeResponse>>(notices);
        return noticesResponse;
    }
}