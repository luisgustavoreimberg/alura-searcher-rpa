using AluraSearcherRPA.Application.DTOs;
using AluraSearcherRPA.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.Application.Services
{
    public class HistoryService : IHistoryService
    {
        public IEnumerable<HistoryResponseDTO> GetAllHistory()
        {
            throw new NotImplementedException();
        }

        public HistoryResponseDTO GetHistory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoryResponseDTO> GetHistory(string searchedValue)
        {
            throw new NotImplementedException();
        }
    }
}
