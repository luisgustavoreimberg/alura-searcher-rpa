using AluraSearcherRPA.Application.Interfaces;
using AluraSearcherRPA.Domain.Entities;
using AluraSearcherRPA.Infrastructure.Interfaces;
using AluraSearcherRPA.RPA.DTOs;
using AluraSearcherRPA.RPA.Interfaces;

namespace AluraSearcherRPA.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IAutomationService _automationService;
        private readonly ISearchRepository _searchRepository;

        public SearchService(IAutomationService automationService, ISearchRepository searchRepository)
        {
            _automationService = automationService;
            _searchRepository = searchRepository;
        }

        public AutomationSearchResponseDTO ExecuteSearch(string valueToSearch)
        {
            var searchDate = DateTime.Now;
            var searchResponse = _automationService.ExecuteAutomationProcess(valueToSearch);

            if (searchResponse is null)
            {
                searchResponse = new AutomationSearchResponseDTO()
                {
                    Error = true,
                    Message = "Fatal Error: No response data"
                };
            }
            else if (!searchResponse.Error && searchResponse.FoundData != null)
            {
                foreach (var response in searchResponse.FoundData)
                {
                    _searchRepository.Insert(new SearchResult()
                    {
                        Title = response.Title,
                        SearchedValue = valueToSearch,
                        SearchDate = searchDate,
                        Instructor = response.Instructor,
                        Duration = response.Duration,
                        Description = response.Description,
                    });
                }
            }

            return searchResponse;
        }
    }
}
