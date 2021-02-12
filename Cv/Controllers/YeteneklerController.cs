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
    public class YeteneklerController : Controller
    {
        // GET: Yetenekler
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var dgr = db.tblSkills.ToList().ToPagedList(sayfa,13);
            return View(dgr);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(tblSkills y)
        {
            db.tblSkills.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index", "Yetenekler");

        }
        public ActionResult YetenekSil(int id)
        {
            var ytn = db.tblSkills.Find(id);
            db.tblSkills.Remove(ytn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VeriGetir(int id)
        {
            var vrlr = db.tblSkills.Find(id);
            return View("VeriGetir", vrlr);
        }
        public ActionResult Guncelle(tblSkills d)
        {
            var dgr = db.tblSkills.Find(d.Id);
            dgr.Skill = d.Skill;
            db.SaveChanges();
            return RedirectToAction("Index", "Yetenekler");
        }
    }
}