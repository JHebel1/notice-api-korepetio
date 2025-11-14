using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notices.Application.Commands.CreateNotice;
using Notices.Application.Queries.GetNoticeById;
using Notices.Application.Responses.Notice;
using Swashbuckle.AspNetCore.Annotations;

namespace NoticesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoticesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Guid))]
    public async Task<IActionResult> CreateNotice([FromBody] CreateNoticeCommand command, CancellationToken token)
    {
        var result = await mediator.Send(command, token);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(NoticeResponse))]
    public async Task<IActionResult> GetNoticeById([FromRoute] Guid id, CancellationToken token)
    {
        var result = await mediator.Send(new GetNoticeByIdQuery(id), token);
        return Ok(result);
    }
}