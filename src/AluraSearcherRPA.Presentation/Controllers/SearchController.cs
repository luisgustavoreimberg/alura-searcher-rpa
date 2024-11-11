using AluraSearcherRPA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AluraSearcherRPA.Presentation.Controllers
{
    [ApiController]
    public class SearchController : BaseController
    {
        private ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("{valueToSearch}")]
        public IActionResult ExecuteSearch([FromRoute] string valueToSearch)
        {
            if (string.IsNullOrWhiteSpace(valueToSearch))
                return BadRequest(valueToSearch);

            var responseData = _searchService.ExecuteSearch(valueToSearch);

            if (responseData.Error)
                return StatusCode((int)HttpStatusCode.InternalServerError, responseData);
            else if (responseData.FoundData != null && responseData.FoundData.Count() > 0)
                return Ok(responseData);
            else
                return NotFound();
        }
    }
}
