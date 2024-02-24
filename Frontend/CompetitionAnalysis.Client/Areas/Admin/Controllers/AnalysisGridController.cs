using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AnalysisGridController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
