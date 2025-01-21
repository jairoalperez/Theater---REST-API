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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // PLAY RELATIONS
        modelBuilder.Entity<Play>()
            .HasOne(p => p.Reference)
            .WithOne(r => r.Play)
            .HasForeignKey<Reference>(r => r.PlayId)
            .HasPrincipalKey<Play>(p => p.PlayId);

        modelBuilder.Entity<Play>()
            .HasMany(p => p.Characters)
            .WithOne(c => c.Play)
            .HasForeignKey(c => c.PlayId)
            .HasPrincipalKey(p => p.PlayId);

        modelBuilder.Entity<Play>()
            .HasMany(p => p.SoundTrack)
            .WithOne(m => m.Play)
            .HasForeignKey(m => m.PlayId)
            .HasPrincipalKey(p => p.PlayId);

        // ACTOR RELATIONS
        modelBuilder.Entity<Actor>()
            .HasMany(a => a.Characters)
            .WithOne(c => c.Actor)
            .HasForeignKey(c => c.ActorId)
            .HasPrincipalKey(a => a.ActorId);

        // CHARACTER RELATIONS
        modelBuilder.Entity<Character>()
            .HasOne(c => c.Actor)
            .WithMany(a => a.Characters)
            .HasForeignKey(c => c.ActorId)
            .HasPrincipalKey(a => a.ActorId);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Play)
            .WithMany(p => p.Characters)
            .HasForeignKey(c => c.PlayId)
            .HasPrincipalKey(p => p.PlayId);

        // MUSIC RELATIONS
        modelBuilder.Entity<Music>()
            .HasOne(m => m.Play)
            .WithMany(p => p.SoundTrack)
            .HasForeignKey(m => m.PlayId)
            .HasPrincipalKey(p => p.PlayId);

        // REFERENCE RELATIONS
        modelBuilder.Entity<Reference>()
            .HasOne(r => r.Play)
            .WithOne(p => p.Reference)
            .HasForeignKey<Reference>(r => r.PlayId)
            .HasPrincipalKey<Play>(p => p.PlayId);

    }
}