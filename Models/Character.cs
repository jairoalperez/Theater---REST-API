using System.Text.Json.Serialization;

namespace Actors_RestAPI.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int? ActorId { get; set; }
        public int PlayId { get; set; }

        public Actor? Actor { get; set; }

        public Play Play { get; set; } = new Play();
    }
}