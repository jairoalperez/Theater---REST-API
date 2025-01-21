using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public required DbSet<Actor> Actors { get; set; }
    public required DbSet<Character> Characters { get; set; }
    public required DbSet<Music> Musics { get; set; }
    public required DbSet<Play> Plays { get; set; }
    public required DbSet<Reference> References { get; set; }

}