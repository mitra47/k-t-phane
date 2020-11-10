using Mvckutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvckutuphane.Controllers
{
    public class panelimController : Controller
    {

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: panelim
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYE.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        public ActionResult Index(TBLUYE p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYE.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.SOYAD = p.SOYAD;
            uye.AD = p.AD;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.OKUL = p.OKUL;

            db.SaveChanges();


            return View();
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYE.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            //ViewBag.z1 = kullanici;
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURU.ToList();
            return View(duyurulistesi);
        }
        

    }
}