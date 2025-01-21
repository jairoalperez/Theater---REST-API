namespace Actors_RestAPI.Models
{
    public class Reference
    {
        public int ReferenceId { get; set; }
        public int PlayId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string? Image { get; set; }
        public string? Link { get; set; }

        public required Play Play { get; set; }
    }
}