using AluraSearcherRPA.Application.DTOs;
using AluraSearcherRPA.Application.Interfaces;
using AluraSearcherRPA.Infrastructure.Interfaces;
using AutoMapper;

namespace AluraSearcherRPA.Application.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IMapper _mapper;

        public HistoryService(ISearchRepository searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }

        public IEnumerable<HistoryResponseDTO> GetAllHistory()
        {
            var response = new List<HistoryResponseDTO>();
            var historyResponseData = _searchRepository.SelectAll();

            if (historyResponseData != null && historyResponseData.Count() > 0)
                response = historyResponseData.Select(data => _mapper.Map<HistoryResponseDTO>(data)).ToList();

            return response;
        }

        public HistoryResponseDTO GetHistory(long id)
        {
            return _mapper.Map<HistoryResponseDTO>(_searchRepository.SelectById(id));
        }

        public IEnumerable<HistoryResponseDTO> GetHistory(string searchedValue)
        {
            var response = new List<HistoryResponseDTO>();
            var historyResponseData = _searchRepository.SelectBySearchValue(searchedValue);

            if (historyResponseData != null && historyResponseData.Count() > 0)
                response = historyResponseData.Select(data => _mapper.Map<HistoryResponseDTO>(data)).ToList();

            return response;
        }
    }
}
