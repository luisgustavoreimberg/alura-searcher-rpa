using AluraSearcherRPA.Domain.Entities;

namespace AluraSearcherRPA.Infrastructure.Interfaces
{
    public interface ISearchRepository
    {
        void Insert(SearchResult courseData);
        IEnumerable<SearchResult> SelectAll();
        SearchResult? SelectById(long id);
        IEnumerable<SearchResult> SelectBySearchValue(string searchedValue);
    }
}
