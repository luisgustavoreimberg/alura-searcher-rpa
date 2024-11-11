using AluraSearcherRPA.Application.DTOs;

namespace AluraSearcherRPA.Application.Interfaces
{
    public interface IHistoryService
    {
        IEnumerable<HistoryResponseDTO> GetAllHistory();
        HistoryResponseDTO GetHistory(long id);
        IEnumerable<HistoryResponseDTO> GetHistory(string searchedValue);
    }
}
