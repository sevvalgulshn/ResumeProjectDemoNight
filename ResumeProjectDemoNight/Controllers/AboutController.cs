using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    [Route("About")] //  ROUTE BURAYA
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }

        // /About  ve /About/Index
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(AboutList));
        }

        // /About/AboutList
        [HttpGet("AboutList")]
        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }

        // /About/CreateAbout
        [HttpGet("CreateAbout")]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost("CreateAbout")]
        public IActionResult CreateAbout(About about)
        {
            if (!ModelState.IsValid)
                return View(about);

            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction(nameof(AboutList));
        }

        // /About/DeleteAbout/5
        [HttpGet("DeleteAbout/{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value == null)
                return RedirectToAction(nameof(AboutList));

            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return RedirectToAction(nameof(AboutList));
        }

        // /About/UpdateAbout/5
        [HttpGet("UpdateAbout/{id}")]
        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value == null)
                return RedirectToAction(nameof(AboutList));

            return View(value);
        }

        [HttpPost("UpdateAbout")]
        public IActionResult UpdateAbout(About about)
        {
            if (!ModelState.IsValid)
                return View(about);

            var value = _context.Abouts.Find(about.AboutId);
            if (value == null)
                return RedirectToAction(nameof(AboutList));

            value.NameSurname = about.NameSurname;
            value.ImageUrl = about.ImageUrl;
            value.Description = about.Description;

            _context.SaveChanges();
            return RedirectToAction(nameof(AboutList));
        }
    }
}
