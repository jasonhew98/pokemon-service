using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.Health;

[Route("api/[controller]")]
[ApiController]
public class HealthController : Controller
{
    public HealthController()
    {
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Accepted)]
    public async Task<IActionResult> Health()
    {
        return Ok("Ok");
    }
}