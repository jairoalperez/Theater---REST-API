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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var character = await _context.Characters
            .Where(c => c.CharacterId == id)
            .Include(c => c.Actor)
            .Include(c => c.Play)
            .Select(c => new
            {
                c.CharacterId,
                c.Name,
                c.Description,
                c.Age,
                c.Gender,
                c.Principal,
                c.Image,
                Actor = new 
                {
                    c.Actor.ActorId,
                    c.Actor.FirstName,
                    c.Actor.LastName,
                    c.Actor.Gender,
                    c.Actor.FrontImage
                },
                Play = new
                {
                    c.Play.PlayId,
                    c.Play.Title,
                    c.Play.Genre,
                    c.Play.Format,
                    c.Play.Poster
                }
            })
            .FirstOrDefaultAsync();

            if (character == null)
            {
                return NotFound(Messages.Characters.NotFound);
            }

            return Ok(character);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    
}