using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Helpers;
using Actors_RestAPI.Models;

namespace Actors_RestAPI.Controllers;

[ApiController]
[Route("api/actors")]

public class ActorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ActorsController(AppDbContext context)
    {
        _context = context;
    }

    

    
}