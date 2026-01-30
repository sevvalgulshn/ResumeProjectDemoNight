using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.AdminViewComponents
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _AdminNavbarComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var totalProjects = _context.Portfolios.Count();
            var unreadMessages = _context.Messages.Count(x => x.IsRead == false);

            return View((totalProjects, unreadMessages));
        }
    }
}
