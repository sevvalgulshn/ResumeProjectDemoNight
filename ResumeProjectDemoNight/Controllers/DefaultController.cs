using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ResumeContext _context;

        public DefaultController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // CONTACT FORM POST -> DB'ye kayıt
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            // basit validasyon (istersen DataAnnotation ekleriz)
            if (string.IsNullOrWhiteSpace(message.NameSurname) ||
                string.IsNullOrWhiteSpace(message.Email) ||
                string.IsNullOrWhiteSpace(message.Subject) ||
                string.IsNullOrWhiteSpace(message.MessageDetail))
            {
                TempData["Error"] = "Lütfen tüm alanları doldurun.";
                return RedirectToAction("Index");
            }

            message.IsRead = false;
            message.SendDate = DateTime.Now;

            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesajınız gönderildi ✅";
            return RedirectToAction("Index");
        }
    }
}
