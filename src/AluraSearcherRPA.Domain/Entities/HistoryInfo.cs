using AluraSearcherRPA.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraSearcherRPA.Domain.Entities
{
    public class HistoryInfo
    {
        public long Id { get; set; }
        public DateTime SearchDate { get; set; }
        public CourseInfo SearchResult { get; set; }

        public HistoryInfo(long id, DateTime searchDate, CourseInfo searchResult)
        {
            Id = id;
            SearchDate = searchDate;
            SearchResult = searchResult;
        }
    }
}
