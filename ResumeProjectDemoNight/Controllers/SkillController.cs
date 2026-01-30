using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class SkillController : Controller
    {
        private readonly ResumeContext _context;

        public SkillController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                return View(skill);

            _context.Skills.Add(skill);
            _context.SaveChanges();
            return RedirectToAction(nameof(SkillList));
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = _context.Skills.Find(id);
            if (value == null)
                return RedirectToAction(nameof(SkillList));

            _context.Skills.Remove(value);
            _context.SaveChanges();
            return RedirectToAction(nameof(SkillList));
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Find(id);
            if (value == null)
                return RedirectToAction(nameof(SkillList));

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                return View(skill);

            var value = _context.Skills.Find(skill.SkillId);
            if (value == null)
                return RedirectToAction(nameof(SkillList));

            value.Title = skill.Title;
            value.Value = skill.Value;
            value.Status = skill.Status;

            _context.SaveChanges();
            return RedirectToAction(nameof(SkillList));
        }
    }
}
