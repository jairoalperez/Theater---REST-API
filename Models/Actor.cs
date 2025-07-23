using System.ComponentModel.DataAnnotations.Schema;

namespace Actors_RestAPI.Models
{
    [Table("actors")]
    public class Actor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DOB { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string SkinColor { get; set; } = string.Empty;
        public string EyeColor { get; set; } = string.Empty;
        public string HairColor { get; set; } = string.Empty;
        public string? FrontImage { get; set; }
        public string? FullBodyImage { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();
    }
}