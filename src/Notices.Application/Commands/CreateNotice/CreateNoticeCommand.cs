using System.Text.Json.Serialization;
using MediatR;
using Notices.Domain.Entities;

namespace Notices.Application.Commands.CreateNotice;

public record CreateNoticeCommand
(
    string  Title,
    string Content,
    Subject Subject,
    List<CreateOfferDto> Offers,
    [property: JsonIgnore] Guid IdentityProviderId = default
) : IRequest<Guid>;