namespace Actors_RestAPI.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int ActorId { get; set; }
        public int PlayId { get; set; }

        public required Actor Actor { get; set; }

        public required Play Play { get; set; }
    }
}