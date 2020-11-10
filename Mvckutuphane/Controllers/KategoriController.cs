using Mvckutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace Mvckutuphane.Controllers
{
    public class KategoriController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kategori
        [Authorize]
        public ActionResult Index()
        {

            var degerler = db.TBLKATAGORI.Where(x=>x.DURUM==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATAGORI p)
        {
            db.TBLKATAGORI.Add(p);
            db.SaveChanges();
            return View();

        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATAGORI.Find(id);
            //db.TBLKATAGORI.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATAGORI.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(TBLKATAGORI p)
        {
            var ktg = db.TBLKATAGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}