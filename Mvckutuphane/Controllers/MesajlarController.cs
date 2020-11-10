using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckutuphane.Models.Entity;

namespace Mvckutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Mesajlar
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["MAIL"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList(); ;

            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var uyemail = (string)Session["MAIL"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemail = (string)Session["MAIL"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH =DateTime.Parse (DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar","Mesajlar");
        }
        public ActionResult MesajSil(int id)

        {
            var mesaj = db.TBLMESAJLAR.Find(id);
            db.TBLMESAJLAR.Remove(mesaj);
            db.SaveChanges();
            return RedirectToAction("");

        }

    }

}