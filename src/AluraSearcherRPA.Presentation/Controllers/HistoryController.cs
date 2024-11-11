using AluraSearcherRPA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AluraSearcherRPA.Presentation.Controllers
{
    [ApiController]
    public class HistoryController : BaseController
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IActionResult GetAllHistory()
        {
            var responseData = _historyService.GetAllHistory();

            if (responseData != null && responseData.Count() > 0)
                return Ok(responseData);
            else
                return NoContent();
        }

        [HttpGet("by-id/{historyId}")]
        public IActionResult GetHistoryById([FromRoute] int id)
        {
            var responseData = _historyService.GetHistory(id);

            if (responseData != null)
                return Ok(responseData);
            else
                return NotFound();
        }

        [HttpGet("by-value/{searchedValue}")]
        public IActionResult GetHistoryBySearchValue([FromRoute] string searchedValue)
        {
            var responseData = _historyService.GetHistory(searchedValue);

            if (responseData != null)
                return Ok(responseData);
            else
                return NotFound();
        }
    }
}