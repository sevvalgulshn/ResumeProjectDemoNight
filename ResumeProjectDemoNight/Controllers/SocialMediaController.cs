using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ResumeContext _context;

        public SocialMediaController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult SocialMediaList()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
                return View(socialMedia);

            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();
            return RedirectToAction(nameof(SocialMediaList));
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            if (value == null)
                return RedirectToAction(nameof(SocialMediaList));

            _context.SocialMedias.Remove(value);
            _context.SaveChanges();
            return RedirectToAction(nameof(SocialMediaList));
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            if (value == null)
                return RedirectToAction(nameof(SocialMediaList));

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
                return View(socialMedia);

            var value = _context.SocialMedias.Find(socialMedia.SocialMediaId);
            if (value == null)
                return RedirectToAction(nameof(SocialMediaList));

            value.Title = socialMedia.Title;
            value.Url = socialMedia.Url;
            value.Icon = socialMedia.Icon;
            value.Status = socialMedia.Status;

            _context.SaveChanges();
            return RedirectToAction(nameof(SocialMediaList));
        }
    }
}
