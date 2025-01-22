using System.ComponentModel.DataAnnotations;

namespace Actors_RestAPI.Models
{
    public class CharacterInsert
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public bool Principal { get; set; }
        public string? Image { get; set; }
        public int? ActorId { get; set; }
        [Required]
        public int PlayId { get; set; }
    }
}