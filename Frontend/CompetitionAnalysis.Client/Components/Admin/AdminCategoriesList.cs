using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Components.Admin
{
    public class AdminCategoriesList:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
