using MediatR;
using Notices.Application.Responses.Notice;

namespace Notices.Application.Commands.RenewNotice;

public record RenewNoticeCommand(Guid NoticeId, Guid KeycloakId) : IRequest<NoticeResponse>;