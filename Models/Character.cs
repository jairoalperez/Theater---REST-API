using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actors_RestAPI.Models
{
    [Table("characters")]
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public bool Principal { get; set; }
        public string? Image { get; set; }
        public int? ActorId { get; set; }
        public int PlayId { get; set; }

        public Actor Actor { get; set; } = new Actor();

        public Play Play { get; set; } = new Play();
    }
}