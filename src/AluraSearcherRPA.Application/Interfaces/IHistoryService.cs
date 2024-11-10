using AluraSearcherRPA.Application.DTOs;

namespace AluraSearcherRPA.Application.Interfaces
{
    public interface IHistoryService
    {
        IEnumerable<HistoryResponseDTO> GetAllHistory();
        HistoryResponseDTO GetHistory(int id);
        IEnumerable<HistoryResponseDTO> GetHistory(string searchedValue);
    }
}
