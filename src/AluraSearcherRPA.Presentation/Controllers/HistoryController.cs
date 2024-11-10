using Microsoft.AspNetCore.Mvc;

namespace AluraSearcherRPA.Presentation.Controllers
{
    [ApiController]
    public class HistoryController : BaseController
    {
        [HttpGet]
        public IActionResult GetAllHistory()
        {
            return Ok();
        }

        [HttpGet("by-id/{historyId}")]
        public IActionResult GetHistoryById([FromRoute] int id)
        {
            return Ok();
        }

        [HttpGet("by-value/{searchedValue}")]
        public IActionResult GetHistoryBySearchValue([FromRoute] string searchedValue)
        {
            return Ok();
        }
    }
}