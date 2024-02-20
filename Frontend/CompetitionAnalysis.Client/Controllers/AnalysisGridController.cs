using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Controllers
{
    public class AnalysisGridController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
