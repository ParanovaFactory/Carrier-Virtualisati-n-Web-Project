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
    public class HobiController : Controller
    {
        // GET: Hobi
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var dgr = db.tblInterest.ToList().ToPagedList(sayfa, 13);
            return View(dgr);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHobi(tblInterest h)
        {
            db.tblInterest.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index", "Hobi");

        }
        public ActionResult HobiSil(int id)
        {
            var hb = db.tblInterest.Find(id);
            db.tblInterest.Remove(hb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VeriGetir(int id)
        {
            var vrlr = db.tblInterest.Find(id);
            return View("VeriGetir", vrlr);
        }
        public ActionResult Guncelle(tblInterest d)
        {
            var dgr = db.tblInterest.Find(d.Id);
            dgr.Interest = d.Interest;
            db.SaveChanges();
            return RedirectToAction("Index", "Hobi");
        }
    }
}