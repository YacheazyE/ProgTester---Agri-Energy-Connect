using Microsoft.AspNetCore.Mvc;
using MVCCow.Models;
using MVCCow.Services;

namespace MVCCow.Controllers
{
    public class FarmController : Controller
    {
        private readonly FarmService _farmService;

        public FarmController(FarmService farmService)
        {
            _farmService = farmService;
        }

        public async Task<IActionResult> Index()
        {
            List<Farm> farms = await _farmService.GetAllFarmsAsync();
            return View(farms);
        }
    }
}
