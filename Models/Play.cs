namespace Actors_RestAPI.Models
{
    public class Play
    {
        public int PlayId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReferenceId { get; set; }
        public string? Poster { get; set; }
    }
}