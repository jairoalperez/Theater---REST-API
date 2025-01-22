using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Models;
using Actors_RestAPI.Helpers;

namespace Actors_RestAPI.Controllers;

[ApiController]
[Route("api/music")]

public class MusicsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MusicsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var music = await _context.Musics
            .Where(m => m.MusicId == id)
            .Include(m => m.Play)
            .Select(m => new
            {
                m.MusicId,
                m.Title,
                m.Artist,
                m.Image,
                m.MusicLink,
                Play = m.Play == null ? null : new 
                {
                    m.Play.PlayId,
                    m.Play.Title,
                    m.Play.Genre,
                    m.Play.Format,
                    m.Play.Poster
                }
            })
            .FirstOrDefaultAsync();

            if (music == null)
            {
                return NotFound(Messages.Musics.NotFound);
            }

            return Ok(music);
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<Music>> Create([FromBody] MusicInsert musicInsert)
    {
        try
        {
            var newMusic = new Music()
            {
                Title = musicInsert.Title,
                Artist = musicInsert.Artist,
                Image = musicInsert.Image,
                MusicLink = musicInsert.MusicLink, 
                PlayId = musicInsert.PlayId
            }; 

            _context.Musics.Add(newMusic);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Musics.Created,
                Music = newMusic
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Music>> Edit([FromRoute] int id, [FromBody] MusicInsert musicInsert)
    {
        try
        {
            var music = await _context.Musics.FirstOrDefaultAsync(i => i.MusicId == id);
            if (music == null)
            {
                return NotFound(Messages.Musics.NotFound);
            }

            music.Title = musicInsert.Title;
            music.Artist = musicInsert.Artist;
            music.Image = musicInsert.Image;
            music.MusicLink = musicInsert.MusicLink;
            music.PlayId = musicInsert.PlayId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Musics.Updated,
                Music = music
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
            var music = await _context.Musics.FirstOrDefaultAsync(i => i.MusicId == id);
            if (music == null)
            {
                return NotFound(Messages.Musics.NotFound);
            }

            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = Messages.Musics.Deleted,
                Music = music
            });
        }
        catch (Exception ex)
        {
            return Problem(Messages.Database.ProblemRelated, ex.Message);
        }
    }
}