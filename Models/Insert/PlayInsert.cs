using System.ComponentModel.DataAnnotations;

namespace Actors_RestAPI.Models
{
    public class PlayInsert
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Genre { get; set; } = string.Empty;
        [Required]
        public string Format { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public int? ReferenceId { get; set; }
        public string? Poster { get; set; }
        public string? ScriptLink { get; set; }

    }
}