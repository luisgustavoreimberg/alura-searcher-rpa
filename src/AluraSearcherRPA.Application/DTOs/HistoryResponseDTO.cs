using AluraSearcherRPA.Domain.DTOs;

namespace AluraSearcherRPA.Application.DTOs
{
    public class HistoryResponseDTO
    {
        public long Id { get; set; }
        public DateTime SearchDate { get; set; }
        public required string SearchedValue { get; set; }
        public IEnumerable<CourseDataDTO> SearchResponseData { get; set; }
    }
}
