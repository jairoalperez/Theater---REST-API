using Actors_RestAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Models;

namespace Actors_RestAPI.Controllers;

[ApiController]
[Route("api/plays")]

public class PlaysController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlaysController(AppDbContext context)
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
            .OrderByDescending(p => p.Characters)
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
                    Characters = p.Characters == null ? null : p.Characters.OrderByDescending(c => c.Principal).Select(c => new
                    {
                        c.CharacterId,
                        c.Name,
                        c.Principal,
                        c.Image,
                        Actor = c.ActorId == null ? null : new
                        {
                            c.Actor.ActorId,
                            c.Actor.FirstName,
                            c.Actor.LastName,
                            c.Actor.FrontImage
                        }
                    }),
                    SoundTrack = p.SoundTrack == null ? null : p.SoundTrack.Select(m => new
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

    [HttpPost("create")]
    public async Task<ActionResult<Play>> Create([FromBody] PlayInsert playInsert)
    {
        try
        {
            var play = await _context.Plays.FirstOrDefaultAsync(p => p.Title == playInsert.Title);
            if (play != null)
            {
                return Problem(Messages.Plays.AlreadyExists);
            }

            var newPlay = new Play()
            {
                Title = playInsert.Title,
                Genre = playInsert.Genre,
                Format = playInsert.Format,
                Description = playInsert.Description,
                ReferenceId = playInsert.ReferenceId,
                Poster = playInsert.Poster,
                ScriptLink = playInsert.ScriptLink
            };

            _context.Plays.Add(newPlay);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Plays.Created,
                Play = newPlay
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Play>> Edit([FromRoute] int id, [FromBody] PlayInsert playInsert)
    {
        try
        {
            var play = await _context.Plays.FirstOrDefaultAsync(i => i.PlayId == id);
            if (play == null)
            {
                return NotFound(Messages.Plays.NotFound);
            }

            play.Title = playInsert.Title;
            play.Genre = playInsert.Genre;
            play.Format = playInsert.Format;
            play.Description = playInsert.Description;
            play.ReferenceId = playInsert.ReferenceId;
            play.Poster = playInsert.Poster;
            play.ScriptLink = playInsert.ScriptLink;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Plays.Updated,
                Play = play
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }


    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Play>> Delete([FromRoute] int id)
    {
        try
        {
            var play = await _context.Plays.FirstOrDefaultAsync(i => i.PlayId == id);
            if (play == null)
            {
                return NotFound(Messages.Plays.NotFound);
            }

            _context.Plays.Remove(play);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Plays.Deleted
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }
}