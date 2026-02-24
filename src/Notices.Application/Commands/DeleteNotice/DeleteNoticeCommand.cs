using MediatR;

namespace Notices.Application.Commands.DeleteNotice;

public record DeleteNoticeCommand(Guid NoticeId, Guid KeycloakId) : IRequest<bool>;