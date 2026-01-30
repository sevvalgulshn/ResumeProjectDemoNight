using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class EducationController : BaseAdminController
    {
        public EducationController(ResumeContext context) : base(context) { }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(EducationList));
        }

        public IActionResult EducationList()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateEducation() => View();

        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            if (!ModelState.IsValid) return View(education);
            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(EducationList));
        }

        public IActionResult DeleteEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value != null)
            {
                _context.Educations.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(EducationList));
        }

        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var value = _context.Educations.Find(id);
            if (value == null) return RedirectToAction(nameof(EducationList));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            if (!ModelState.IsValid) return View(education);

            var value = _context.Educations.Find(education.EducationId);
            if (value == null) return RedirectToAction(nameof(EducationList));

            value.SchoolName = education.SchoolName;
            value.Department = education.Department;
            value.Date = education.Date;

            _context.SaveChanges();
            return RedirectToAction(nameof(EducationList));
        }
    }
}
