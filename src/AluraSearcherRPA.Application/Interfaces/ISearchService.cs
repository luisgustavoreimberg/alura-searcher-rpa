using AluraSearcherRPA.Application.DTOs;

namespace AluraSearcherRPA.Application.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<SearchResponseDTO> ExecuteSearch();
    }
}
