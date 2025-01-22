using Actors_RestAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var playsQuery = _context.Plays.Include(p => p.Characters);
            var allPlays = await playsQuery.Select(p => new
            {
                p.PlayId,
                p.Title,
                p.Genre,
                p.Format,
                p.Poster,
                Characters = p.Characters.Count
            })
            .ToListAsync();

            if (allPlays.Count < 1)
            {
                return NotFound(Messages.Plays.NotFound);
            }

            return Ok(allPlays);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpGet("all/{format}")]
    public async Task<IActionResult> GetAllFormat([FromRoute] String format)
    {
        try
        {
            var playsQuery = _context.Plays.Where(p => p.Format == format).Include(p => p.Characters);
            var allPlays = await playsQuery.Select(p => new
            {
                p.PlayId,
                p.Title,
                p.Genre,
                p.Format,
                p.Poster,
                Characters = p.Characters.Count
            })
            .ToListAsync();

            if (allPlays.Count < 1)
            {
                return NotFound(Messages.Plays.NotFound);
            }

            return Ok(allPlays);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var play = await _context.Plays
                .Where(p => p.PlayId == id)
                .Include(p => p.Characters)
                    .ThenInclude(c => c.Actor)
                .Include(p => p.SoundTrack)
                .Include(p => p.Reference)
                .Select(p => new
                {
                    p.PlayId,
                    p.Title,
                    p.Genre,
                    p.Format,
                    p.Description,
                    p.Poster,
                    p.ScriptLink,
                    Reference = p.Reference == null ? null : new
                    {
                        p.Reference.ReferenceId,
                        p.Reference.Title,
                        p.Reference.Author,
                        p.Reference.ReleaseDate,
                        p.Reference.Image
                    },
                    Characters = p.Characters.Select(c => new
                    {
                        c.CharacterId,
                        c.Name,
                        c.Principal,
                        c.Image,
                        Actor = new
                        {
                            c.Actor.ActorId,
                            c.Actor.FirstName,
                            c.Actor.LastName,
                            c.Actor.FrontImage
                        }
                    }),
                    SoundTrack = p.SoundTrack.Select(m => new
                    {
                        m.MusicId,
                        m.Title,
                        m.Artist,
                        m.Image,
                        m.MusicLink
                    })
                })
                .FirstOrDefaultAsync();

            if (play == null)
            {
                return NotFound(Messages.Plays.NotFound);
            }

            return Ok(play);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    
}