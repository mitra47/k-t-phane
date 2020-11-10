using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckutuphane.Models.Entity;

namespace Mvckutuphane.Controllers
{
    public class IslemController : Controller

    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Islem
        [Authorize]
        public ActionResult Index()
        {

            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}