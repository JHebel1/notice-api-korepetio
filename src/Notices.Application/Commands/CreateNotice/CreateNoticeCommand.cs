using MediatR;
using Notices.Domain.Entities;

namespace Notices.Application.Commands.CreateNotice;

public record CreateNoticeCommand
(
    string  Title,
    string Content,
    Guid OwnerId,
    Guid SubjectId,
    List<Guid> OfferIds
) : IRequest<Guid>;