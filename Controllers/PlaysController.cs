using Microsoft.AspNetCore.Mvc;

namespace Actors_RestAPI.Controllers;

[ApiController]
[Route("api/plays")]

public class PlaysController : ControllerBase
{
    private readonly AppDbContext _context;

    private PlaysController(AppDbContext context)
    {
        _context = context;
    }
}