namespace AluraSearcherRPA.Domain.DTOs
{
    public class CourseDataDTO
    {
        public required string Title { get; set; }
        public string? Instructor { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
    }
}
