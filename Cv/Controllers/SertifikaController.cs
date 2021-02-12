using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entiity;
using Cv.Models.Sinif;

namespace Cv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index(string p)
        {
            var dgr = from d in db.tblAward select d;
            if (!string.IsNullOrEmpty(p))
            {
                dgr = dgr.Where(m => m.Award.Contains(p));
            }
            return View(dgr.ToList());
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(tblAward s)
        {
            db.tblAward.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index", "Sertifika");

        }
        public ActionResult SertifikaSil(int id)
        {
            var srt = db.tblAward.Find(id);
            db.tblAward.Remove(srt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VeriGetir(int id)
        {
            var vrlr = db.tblAward.Find(id);
            return View("VeriGetir", vrlr);
        }
        public ActionResult Guncelle(tblAward d)
        {
            var dgr = db.tblAward.Find(d.Id);
            dgr.Award = d.Award;
            db.SaveChanges();
            return RedirectToAction("Index", "Sertifika");
        }
    }
}