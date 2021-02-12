using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models.Entiity;
using Cv.Models.Sinif;

namespace Cv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.tblAbout.ToList();
            cs.Deger2 = db.tblExperience.ToList();
            cs.Deger3 = db.tblAducation.ToList();
            cs.Deger4 = db.tblSkills.ToList();
            cs.Deger5 = db.tblInterest.ToList();
            cs.Deger6 = db.tblAward.ToList();
            return View(cs);
            //var dgr = db.tblAbout.ToList();
            //return View(dgr);
        }
    }
}