using System.ComponentModel.DataAnnotations;

namespace Actors_RestAPI.Models
{
    public class ActorInsert
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string DOB { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string SkinColor { get; set; } = string.Empty;
        [Required]
        public string EyeColor { get; set; } = string.Empty;
        [Required]
        public string HairColor { get; set; } = string.Empty;
        public string? FrontImage { get; set; }
        public string? FullBodyImage { get; set; }
        
    }
}

