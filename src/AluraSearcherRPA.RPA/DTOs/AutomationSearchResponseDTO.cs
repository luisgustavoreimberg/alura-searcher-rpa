using AluraSearcherRPA.Domain.DTOs;

namespace AluraSearcherRPA.RPA.DTOs
{
    public class AutomationSearchResponseDTO
    {
        public bool Error { get; set; }
        public string? Message { get; set; }
        public IEnumerable<CourseDataDTO> FoundData { get; set; }
    }
}
