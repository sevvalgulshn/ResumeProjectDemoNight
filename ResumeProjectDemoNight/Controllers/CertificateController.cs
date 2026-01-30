using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class CertificateController : BaseAdminController
    {
        public CertificateController(ResumeContext context) : base(context) { }

        // LIST
        public IActionResult CertificateList()
        {
            var values = _context.Certificates.ToList();
            return View(values);
        }

        // CREATE
        [HttpGet]
        public IActionResult CreateCertificate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            return RedirectToAction("CertificateList");
        }

        // UPDATE
        [HttpGet]
        public IActionResult UpdateCertificate(int id)
        {
            var value = _context.Certificates.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCertificate(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
            _context.SaveChanges();
            return RedirectToAction("CertificateList");
        }

        // DELETE
        public IActionResult DeleteCertificate(int id)
        {
            var value = _context.Certificates.Find(id);
            if (value != null)
            {
                _context.Certificates.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("CertificateList");
        }
    }
}
