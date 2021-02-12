using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entiity;
using Cv.Models.Sinif;
using PagedList;
using PagedList.Mvc;

namespace Cv.Controllers
{
    public class DeneyimlerimController : Controller
    {
        // GET: Deneyimlerim
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var dgr = db.tblExperience.ToList().ToPagedList(sayfa, 13);
            return View(dgr);
        }
        [HttpGet]
        public ActionResult YeniDeneyim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDeneyim(tblExperience d)
        {
            db.tblExperience.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index", "Deneyimlerim");
        }
        public ActionResult DeneyimSil(int id)
        {
            var dnym = db.tblExperience.Find(id);
            db.tblExperience.Remove(dnym);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VeriGetir(int id)
        {
            var vrlr = db.tblExperience.Find(id);
            return View("VeriGetir", vrlr);
        }
        public ActionResult Guncelle(tblExperience d)
        {
            var dgr = db.tblExperience.Find(d.Id);
            dgr.Title = d.Title;
            dgr.SubTitle = d.SubTitle;
            dgr.Date = d.Date;
            dgr.Details = d.Details;
            db.SaveChanges();
            return RedirectToAction("Index", "Deneyimlerim");
        }
    }
}