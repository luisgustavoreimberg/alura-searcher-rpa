namespace AluraSearcherRPA.Application.DTOs
{
    public class HistoryResponseDTO(long id, DateTime searchDate, SearchResponseDTO searchResponseData)
    {
        public long Id { get; set; } = id;
        public DateTime SearchDate { get; set; } = searchDate;
        public SearchResponseDTO SearchResponseData { get; set; } = searchResponseData;
    }
}
