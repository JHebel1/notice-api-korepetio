using MediatR;
using Notices.Application.DTO;
using Notices.Domain.Entities;

namespace Notices.Application.Commands.CreateNotice;

public record CreateNoticeCommand
(
    string  Title,
    string Content,
    Guid OwnerId,
    Subject Subject,
    List<CreateOfferDto> Offers
) : IRequest<Guid>;