using System.ComponentModel.DataAnnotations.Schema;

namespace Actors_RestAPI.Models
{
    [Table("musics")]
    public class Music
    {
        public int MusicId { get; set; }
        public int PlayId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? MusicLink { get; set; }

        public Play? Play { get; set; }
    }
}