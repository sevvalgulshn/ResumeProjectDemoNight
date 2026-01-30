using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;         
using System.Linq;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;   // Context class adı sende farklı olabilir

        public _DefaultExperienceComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences
                                 .OrderByDescending(x => x.ExperienceId)
                                 .ToList();

            return View(values);
        }
    }
}
