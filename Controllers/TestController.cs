using Microsoft.AspNetCore.Mvc;
using Actors_RestAPI.Helpers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet()]
    public IActionResult TestAPI()
    {
        return Ok(Messages.API.Working);
    }
}