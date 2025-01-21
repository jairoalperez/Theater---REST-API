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

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allActors = await _context.Actors.ToListAsync();
            if (allActors.Count < 1)
            {
                return NotFound(Messages.Actors.NotFound);
            }

            return Ok(allActors);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpGet("all/{gender}")]
    public async Task<IActionResult> GetByGender([FromRoute] string gender)
    {
        try
        {
            var allActors = await _context.Actors.Where(a => a.Gender == gender).ToListAsync();
            if (allActors.Count < 1)
            {
                return NotFound(Messages.Actors.NotFound);
            }

            return Ok(allActors);
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
            var actor = await _context.Actors.FirstOrDefaultAsync(i => i.ActorId == id);
            if (actor == null)
            {
                return NotFound(Messages.Actors.NotFound);
            }

            return Ok(actor);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<Actor>> Create([FromBody] ActorInsert actorInsert)
    {
        try
        {
            var newActor = new Actor()
            {
                FirstName = actorInsert.FirstName,
                LastName = actorInsert.LastName,
                DOB = actorInsert.DOB,
                Gender = actorInsert.Gender,
                SkinColor = actorInsert.SkinColor,
                EyeColor = actorInsert.EyeColor,
                HairColor = actorInsert.HairColor,
                FrontImage = actorInsert.FrontImage,
                FullBodyImage = actorInsert.FullBodyImage
            };

            _context.Actors.Add(newActor);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Actors.Created,
                Actor = newActor
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Actor>> Edit([FromRoute] int id, [FromBody] ActorInsert actorInsert)
    {
        try
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(i => i.ActorId == id);
            if (actor == null)
            {
                return NotFound(Messages.Actors.NotFound);
            }

            actor.FirstName = actorInsert.FirstName;
            actor.LastName = actorInsert.LastName;
            actor.DOB = actorInsert.DOB;
            actor.Gender = actorInsert.Gender;
            actor.SkinColor = actorInsert.SkinColor;
            actor.EyeColor = actorInsert.EyeColor;
            actor.HairColor = actorInsert.HairColor;
            actor.FrontImage = actorInsert.FrontImage;
            actor.FullBodyImage = actorInsert.FullBodyImage;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Actors.Updated,
                Actor = actor
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    
}