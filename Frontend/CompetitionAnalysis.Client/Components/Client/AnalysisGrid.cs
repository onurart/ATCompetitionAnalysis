using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Components.Client
{
    public class AnalysisGrid:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
