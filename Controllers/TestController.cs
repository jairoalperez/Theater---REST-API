using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet()]
    public IActionResult TestAPI()
    {
        return Ok("API is working");
    }
}