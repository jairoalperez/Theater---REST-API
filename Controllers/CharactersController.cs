using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Models;
using Actors_RestAPI.Helpers;

namespace Actors_RestAPI.Controllers;

[ApiController]
[Route("api/characters")]

public class CharactersController : ControllerBase
{
    private readonly AppDbContext _context;

    public CharactersController(AppDbContext context)
    {
        _context = context;
    }

    
}