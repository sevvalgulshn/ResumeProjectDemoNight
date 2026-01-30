using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.NameSurname) ||
                string.IsNullOrWhiteSpace(message.Email) ||
                string.IsNullOrWhiteSpace(message.Subject) ||
                string.IsNullOrWhiteSpace(message.MessageDetail))
            {
                TempData["Error"] = "Lütfen tüm alanları doldurun.";
                return RedirectToAction("Index", "Default");
            }

            message.IsRead = false;
            message.SendDate = DateTime.Now;

            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesajınız gönderildi ✅";
            return RedirectToAction("Index", "Default");
        }
    }
}
