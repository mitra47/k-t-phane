using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckutuphane.Models.Entity;
namespace Mvckutuphane.Controllers
{

    public class KayitOlController : Controller
    {

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        // GET: KayitOl
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLUYE p)
        {

            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYE.Add(p);
            db.SaveChanges();
            TBLUYEROL rol = new TBLUYEROL();
            rol.RolID = 1;
            rol.ID = p.ID;
            //ICollection<TBLUYEROL> roller = new Collection<TBLUYEROL>();
            //roller.Add(rol);
            //p.TBLUYEROL = roller;
            db.TBLUYEROL.Add(rol);
            db.SaveChanges();
            return View();
        }
    }
}