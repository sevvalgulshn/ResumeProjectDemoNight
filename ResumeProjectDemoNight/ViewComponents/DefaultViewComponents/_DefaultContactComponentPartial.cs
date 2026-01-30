using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new Message());
        }
    }
}
