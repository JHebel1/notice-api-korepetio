using MediatR;
namespace Notices.Application.Commands.CreateNotice;

public record CreateNoticeCommand
(
    string  Title,
    string Content
) : IRequest<Guid>;