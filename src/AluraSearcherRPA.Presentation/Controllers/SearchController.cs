using Microsoft.AspNetCore.Mvc;

namespace AluraSearcherRPA.Presentation.Controllers
{
    [ApiController]
    public class SearchController : BaseController
    {
        [HttpGet("{valueToSearch}")]
        public IActionResult ExecuteSearch([FromRoute] string valueToSearch)
        {
            if (string.IsNullOrWhiteSpace(valueToSearch))
                return BadRequest();
            else
                return Ok();
        }
    }
}
