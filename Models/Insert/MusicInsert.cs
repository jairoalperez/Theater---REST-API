using System.ComponentModel.DataAnnotations;

namespace Actors_RestAPI.Models
{
    public class MusicInsert
    {
        [Required]
        public int PlayId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Artist { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? MusicLink { get; set; }
    }
}