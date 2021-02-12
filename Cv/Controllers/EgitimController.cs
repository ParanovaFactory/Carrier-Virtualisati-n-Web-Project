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
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var dgr = db.tblAducation.ToList().ToPagedList(sayfa, 13);
            return View(dgr);
        }
        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniEgitim(tblAducation e)
        {
            db.tblAducation.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index", "Egitim");

        }
        public ActionResult EgitimSil(int id)
        {
            var egt = db.tblAducation.Find(id);
            db.tblAducation.Remove(egt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VeriGetir(int id)
        {
            var vrlr = db.tblAducation.Find(id);
            return View("VeriGetir", vrlr);
        }
        public ActionResult Guncelle(tblAducation d)
        {
            var dgr = db.tblAducation.Find(d.Id);
            dgr.Title = d.Title;
            dgr.SubTitle = d.SubTitle;
            dgr.Departmet = d.Departmet;
            dgr.Gpa = d.Gpa;
            db.SaveChanges();
            return RedirectToAction("Index", "Egitim");
        }
    }
}