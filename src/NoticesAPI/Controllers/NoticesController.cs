using System.Net;
using Microsoft.AspNetCore.Mvc;
using Notices.Application.Services;
using Swashbuckle.AspNetCore.Annotations;
using Notices.Domain.RepositoryInterfaces;
using Notices.Model.Requests.Notice;
using Notices.Model.Responses.Notice;

namespace NoticesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoticesController(INoticeService noticeService) : ControllerBase
{
    [HttpPost]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Guid))]
    public async Task<IActionResult> CreateNotice([FromBody] NoticeRequest request, CancellationToken token)
    {
        var result = await noticeService.CreateNotice(request, token);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(NoticeResponse))]
    public async Task<IActionResult> GetNoticeById([FromRoute] Guid id, CancellationToken token)
    {
        var result = await noticeService.GetNoticeById(id, token);
        return Ok(result);
    }
}