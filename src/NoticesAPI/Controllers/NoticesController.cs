using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notices.Application.Commands.CreateNotice;
using Notices.Application.Commands.DeleteNotice;
using Notices.Application.Commands.RenewNotice;
using Notices.Application.Commands.UpdateNotice;
using Notices.Application.Queries.GetAllNotices;
using Notices.Application.Queries.GetNoticeById;
using Notices.Application.Responses.Notice;
using Swashbuckle.AspNetCore.Annotations;

namespace NoticesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoticesController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Guid))]
    public async Task<IActionResult> CreateNotice([FromBody] CreateNoticeCommand command, CancellationToken token)
    {
        var subClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(subClaim, out var keycloakId))
        {
            return Unauthorized("User id in token is required.");
        }

        var commandWithUser = command with { IdentityProviderId = keycloakId };
        var result = await mediator.Send(commandWithUser, token);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(NoticeResponse))]
    public async Task<IActionResult> GetNoticeById([FromRoute] Guid id, CancellationToken token)
    {
        var result = await mediator.Send(new GetNoticeByIdQuery(id), token);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<NoticeResponse>))]
    public async Task<IActionResult> GetAllNotices(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken token = default)
    {
        var result = await mediator.Send(new GetAllNoticesQuery(page, pageSize), token);
        return Ok(result);
    }

    [Authorize]
    [HttpPatch("{id}/renew")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(NoticeResponse))]
    public async Task<IActionResult> Extend(Guid id, CancellationToken token)
    {
        var subClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(subClaim, out var keycloakId))
        {
            return Unauthorized("User id in token is required.");
        }

        var result = await mediator.Send(new RenewNoticeCommand(id, keycloakId), token);
        return Ok(result);
    }

    [Authorize]
    [HttpPut("{id}")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(NoticeResponse))]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNoticeCommand command, CancellationToken token)
    {
        var subClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(subClaim, out var keycloakId))
        { 
            return Unauthorized("User id in token is required.");
        }
        
        var commandWithUser = command with { IdentityProviderId = keycloakId, NoticeId = id};
        
        var result = await mediator.Send(commandWithUser, token);
        return Ok(result);
    }
    [Authorize]
    [HttpDelete("{id}")]
    [SwaggerResponse((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteNotice([FromRoute] Guid id, CancellationToken token)
    {
        var subClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(subClaim, out var keycloakId))
        {
            return Unauthorized("User id in token is required.");
        }

        var result = await mediator.Send(new DeleteNoticeCommand(id, keycloakId), token);
        return Ok(result);
    }
}