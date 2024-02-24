using Microsoft.AspNetCore.Mvc;

namespace CompetitionAnalysis.Client.Components.Admin
{
    public class SideMenu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
