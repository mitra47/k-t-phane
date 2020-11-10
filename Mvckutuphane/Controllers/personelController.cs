using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckutuphane.Models.Entity;
namespace Mvckutuphane.Controllers
{
    public class personelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: personel
        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();


            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()

        {
            return View();

        }
        [HttpPost]

        public ActionResult PersonelEkle(TBLPERSONEL p)
        {
           

            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);

            return View("PersonelGetir",prs);

        }

        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");



        }





    }
}