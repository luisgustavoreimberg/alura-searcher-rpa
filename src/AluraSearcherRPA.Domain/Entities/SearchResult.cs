namespace AluraSearcherRPA.Domain.Entities
{
    public class SearchResult
    {
        public long Id { get; set; }
        public required string SearchedValue { get; set; }
        public DateTime SearchDate { get; set; }
        public required string Title { get; set; }
        public string? Instructor { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
    }
}
