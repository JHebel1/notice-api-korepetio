using MediatR;
using Notices.Application.Responses.Notice;

namespace Notices.Application.Queries.GetNoticeById;

public record GetNoticeByIdQuery(Guid id) : IRequest<NoticeResponse>;