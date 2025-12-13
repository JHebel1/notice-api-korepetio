using System.Net;
using Microsoft.AspNetCore.Mvc;
using Notices.Application.DTO;
using Notices.Domain.Common;
using Notices.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;


namespace NoticesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectsController : ControllerBase
{
    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<SubjectDto>))]
    public IActionResult GetSubjects(CancellationToken token)
    {
        var levels = Enum.GetValues<Subject>()
            .Select(x => new SubjectDto(
                Id: (int)x,
                Name: x.GetDisplayName())
            ).ToList();

        return Ok(levels);
    }
}