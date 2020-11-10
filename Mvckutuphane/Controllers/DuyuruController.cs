using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckutuphane.Models.Entity;

namespace Mvckutuphane.Controllers
{
    
    public class DuyuruController : Controller
    {
        
        // GET: Duyuru
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities ();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURU.ToList();
            return View(degerler);
        }
        [HttpGet]
         public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult YeniDuyuru(TBLDUYURU t)
        {
            db.TBLDUYURU.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }  
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURU.Find(id);
            db.TBLDUYURU.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DuyuruDetay(TBLDUYURU p)
        {
            var duyuru = db.TBLDUYURU.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncele(TBLDUYURU p)
        {
            var duyuru = db.TBLDUYURU.Find(p.ID);
            duyuru.KATAGORİ = p.KATAGORİ;
            duyuru.ICERIK = p.ICERIK;
            duyuru.TARIH = p.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}