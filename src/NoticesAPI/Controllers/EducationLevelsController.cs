using System.Net;
using Microsoft.AspNetCore.Mvc;
using Notices.Application.DTO;
using Notices.Domain.Common;
using Notices.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;


namespace NoticesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationLevelsController : ControllerBase
{
    [HttpGet]
    [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<EducationLevelDto>))]
    public IActionResult GetEducationalLevels(CancellationToken token)
    {
        var levels = Enum.GetValues<EducationLevel>()
            .Select(x => new EducationLevelDto(
                Id: (int)x,
                Name: x.GetDisplayName())
            ).ToList();

        return Ok(levels);
    }
}