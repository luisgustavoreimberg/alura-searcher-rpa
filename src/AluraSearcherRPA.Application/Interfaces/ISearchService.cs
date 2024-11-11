using AluraSearcherRPA.RPA.DTOs;

namespace AluraSearcherRPA.Application.Interfaces
{
    public interface ISearchService
    {
        AutomationSearchResponseDTO ExecuteSearch(string valueToSearch);
    }
}
