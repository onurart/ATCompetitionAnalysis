using CompetitionAnalysis.Client.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}