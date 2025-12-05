using AutoMapper;
using MediatR;
using Notices.Application.Responses.Notice;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Queries.GetNoticeById;

public class GetNoticeByIdQueryHandler(INoticeRepository noticeRepository, IMapper mapper) : IRequestHandler<GetNoticeByIdQuery, NoticeResponse>
{
    public async Task<NoticeResponse> Handle(GetNoticeByIdQuery query, CancellationToken cancellationToken)
    {
        var notice = await noticeRepository.GetNoticeById(query.Id, cancellationToken);
        var noticeResponse = mapper.Map<NoticeResponse>(notice);
        return noticeResponse;
    }
}