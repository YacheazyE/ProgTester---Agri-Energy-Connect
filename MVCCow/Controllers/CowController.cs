using Microsoft.AspNetCore.Mvc;
using MVCCow.Models;
using MVCCow.Services;

namespace MVCCow.Controllers
{
    public class CowController : Controller
    {
        private readonly CowService _cowService;

        public CowController(CowService cowService)
        {
            _cowService = cowService;
        }

        public async Task<IActionResult> Index()
        {
            List<Cow> cows = await _cowService.GetAllCowsAsync();
            return View(cows);
        }
    }
}
