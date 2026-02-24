using System.Text.Json.Serialization;
using MediatR;
using Notices.Application.Commands.CreateNotice;
using Notices.Application.Responses.Notice;
using Notices.Domain.Entities;

namespace Notices.Application.Commands.UpdateNotice;

public record UpdateNoticeCommand
(
    string  Title,
    string Content,
    Subject Subject,
    List<CreateOfferDto> Offers,
    [property: JsonIgnore] Guid IdentityProviderId = default,
    [property: JsonIgnore] Guid NoticeId = default
) : IRequest<NoticeResponse>;