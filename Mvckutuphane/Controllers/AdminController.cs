using Mvckutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvckutuphane.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [Authorize ]
        public ActionResult Index()
        {
            var degerler = db.TBLADMİN.ToList();
            return View(degerler);
        }

        [HttpGet]

        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AdminEkle(TBLADMİN ad)
        {
            if (!ModelState.IsValid)
            {
                return View("AdminEkle");
            }

            db.TBLADMİN.Add(ad);
            db.SaveChanges();
            return View();
        }

        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMİN.Find(id);
            db.TBLADMİN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult AdminGetir(int id)
        {
            var admin = db.TBLADMİN.Find(id);
            return View("AdminGetir", admin);
        }

        public ActionResult AdminGuncelle(TBLADMİN ad)
        {
            var admin = db.TBLADMİN.Find(ad.Admin_id);
            admin.KULLANICIADİ = ad.KULLANICIADİ;
            admin.MAIL = ad.MAIL;
            admin.SIFRE = ad.SIFRE;
            ;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}