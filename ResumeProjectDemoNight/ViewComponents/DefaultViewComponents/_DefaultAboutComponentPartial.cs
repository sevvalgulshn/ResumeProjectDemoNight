using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultAboutComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var about = _context.Abouts.FirstOrDefault();
            var skills = _context.Skills.Where(x => x.Status == true).ToList();


            ViewBag.SkillList = skills;

            // about null ise view patlamasın diye boş obje döndür
            if (about == null)
                return View(new ResumeProjectDemoNight.Entities.About());

            return View(about);
        }
    }
}

