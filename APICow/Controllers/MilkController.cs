using Microsoft.AspNetCore.Mvc;

namespace APICow.Controllers
{
    public class MilkController : Controller
    {
        [HttpGet("GetMeMilk")]
        public IActionResult GetGotMilk()
        {
            return Ok("Here is milk :) ");
        }
    }
}
