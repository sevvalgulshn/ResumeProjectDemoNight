using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class BaseAdminController : Controller
    {
        protected readonly ResumeContext _context;

        public BaseAdminController(ResumeContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Üst bar sayaçlar
            ViewBag.TopTotalProjects = _context.Portfolios.Count();
            ViewBag.TopUnreadMessages = _context.Messages.Count(x => x.IsRead == false);

            // ✅ Admin adı + profil foto (DB’den)
            var about = _context.Abouts.FirstOrDefault();

            ViewBag.AdminName = !string.IsNullOrWhiteSpace(about?.NameSurname)
                ? about.NameSurname
                : "Şevval";

            ViewBag.ProfileImage = !string.IsNullOrWhiteSpace(about?.ImageUrl)
                ? about.ImageUrl
                : "/images/sevval-foto.jpg";

            base.OnActionExecuting(context);
        }
    }
}
