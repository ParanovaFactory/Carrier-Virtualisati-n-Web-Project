using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entiity;
using Cv.Models.Sinif;

namespace Cv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.tblAbout.ToList();
            return View(cs);
        }
        public ActionResult VeriGetir(int id)
        {
            var vrlr = db.tblAbout.Find(id);
            return View("VeriGetir", vrlr);
        }
        public ActionResult Guncelle(tblAbout p)
        {
            var dgr = db.tblAbout.Find(p.Id);
            dgr.Name = p.Name;
            dgr.Surname = p.Surname;
            dgr.Adderss = p.Adderss;
            dgr.Phone = p.Phone;
            dgr.Mail = p.Mail;
            dgr.About = p.About;
            db.SaveChanges();
            return RedirectToAction("Index","Hakkimda");
        }
    }
}