using MediatR;
using Notices.Application.Responses.Notice;

namespace Notices.Application.Queries.GetAllNotices;

public record GetAllNoticesQuery(int page, int pageSize): IRequest<List<NoticeResponse>>;