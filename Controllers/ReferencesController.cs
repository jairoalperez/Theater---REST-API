using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Models;
using Actors_RestAPI.Helpers;

namespace Actors_RestAPI.Controllers;

[ApiController]
[Route("api/reference")]

public class ReferencesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReferencesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var reference = await _context.References
            .Where(r => r.ReferenceId == id)
            .Include(r => r.Play)
            .Select(r => new
            {
                r.ReferenceId,
                r.Title,
                r.Description,
                r.Author,
                r.Type,
                r.ReleaseDate,
                r.Genre,
                r.Image,
                r.Link,
                Play = r.Play == null ? null : new 
                {
                    r.Play.PlayId,
                    r.Play.Title,
                    r.Play.Genre,
                    r.Play.Format,
                    r.Play.Poster
                }
            })
            .FirstOrDefaultAsync();

            if (reference == null)
            {
                return NotFound(Messages.References.NotFound);
            }

            return Ok(reference);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<Reference>> Create([FromBody] ReferenceInsert referenceInsert)
    {
        try
        {
            var newReference = new Reference()
            {
                Title = referenceInsert.Title,
                PlayId = referenceInsert.PlayId,
                Description = referenceInsert.Description,
                Author = referenceInsert.Author,
                Type = referenceInsert.Type,
                ReleaseDate = referenceInsert.ReleaseDate,
                Genre = referenceInsert.Genre,
                Image = referenceInsert.Image,
                Link = referenceInsert.Link
            }; 

            _context.References.Add(newReference);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.References.Created,
                Reference = newReference
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Reference>> Edit([FromRoute] int id, [FromBody] ReferenceInsert referenceInsert)
    {
        try
        {
            var reference = await _context.References.FirstOrDefaultAsync(i => i.ReferenceId == id);
            if (reference == null)
            {
                return NotFound(Messages.References.NotFound);
            }

            reference.Title = referenceInsert.Title;
            reference.PlayId = referenceInsert.PlayId;
            reference.Description = referenceInsert.Description;
            reference.Author = referenceInsert.Author;
            reference.Type = referenceInsert.Type;
            reference.ReleaseDate = referenceInsert.ReleaseDate;
            reference.Genre = referenceInsert.Genre;
            reference.Image = referenceInsert.Image;
            reference.Link = referenceInsert.Link;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.References.Updated,
                Reference = reference
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var reference = await _context.References.FirstOrDefaultAsync(i => i.ReferenceId == id);
            if (reference == null)
            {
                return NotFound(Messages.References.NotFound);
            }

            _context.References.Remove(reference);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.References.Deleted,
                Reference = reference
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }
}