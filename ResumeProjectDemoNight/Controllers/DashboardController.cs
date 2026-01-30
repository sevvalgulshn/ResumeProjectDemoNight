using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class DashboardController : BaseAdminController
    {
        public DashboardController(ResumeContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault() ?? new About();

            // ✅ Profil foto: DB'de varsa onu kullan, yoksa default sevval-foto.jpg
            ViewBag.ProfileImage = !string.IsNullOrWhiteSpace(about.ImageUrl)
                ? about.ImageUrl
                : "/images/sevval-foto.jpg";

            // ✅ Hoş geldin yazısı (şimdilik sabit; istersen DB'den de çekebiliriz)
            ViewBag.AdminName = "Şevval";

            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.ActiveProjects = _context.Portfolios.Count(x => x.Status == true);
            ViewBag.CompletedProjects = _context.Portfolios.Count(x => x.Status == false);

            ViewBag.TotalSkills = _context.Skills.Count();

            ViewBag.TotalMessages = _context.Messages.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => x.IsRead == false);

            ViewBag.TotalCertificates = _context.Certificates.Count();
            ViewBag.ActiveCertificates = _context.Certificates.Count(x => x.Status == true);

            ViewBag.TotalEducations = _context.Educations.Count();
            ViewBag.TotalExperiences = _context.Experiences.Count();
            ViewBag.TotalServices = _context.Services.Count();
            ViewBag.TotalTestimonials = _context.Testimonials.Count();

            ViewBag.StatisticCards = _context.Statistics
                .Where(x => x.Status == true)
                .OrderBy(x => x.StatisticId)
                .Take(4)
                .ToList();

            return View(about);
        }
    }
}
