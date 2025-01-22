using System.ComponentModel.DataAnnotations;

namespace Actors_RestAPI.Models
{
    public class ReferenceInsert
    {
        [Required]
        public int PlayId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Genre { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Link { get; set; }
    }
}