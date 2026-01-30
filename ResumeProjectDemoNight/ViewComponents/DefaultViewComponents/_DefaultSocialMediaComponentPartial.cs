using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultSocialMediaComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultSocialMediaComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.SocialMedias.Where(x => x.Status).ToList();
            return View(values);

        }
    }
}
