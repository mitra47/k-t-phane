using Mvckutuphane.Models.Sınıflarım;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckutuphane.Models.Entity;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Net;
using PagedList;
using PagedList.Mvc;

namespace Mvckutuphane.Controllers
{
    public class IletisimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Iletisim
        [Authorize]
        public ActionResult Index()
        {

            var degerler = db.TBLILETISIM.ToList();
            return View(degerler);
        }


        [HttpPost]
        public ActionResult Index(TBLILETISIM model)

        {
           

            MailMessage _mm = new MailMessage();
            _mm.SubjectEncoding = Encoding.Default;
            //_mm.Subject = model.ID;
            _mm.Subject = model.AD;
            _mm.Subject = model.MAIL;
            _mm.Subject = model.KONU;

            _mm.BodyEncoding = Encoding.Default;
            _mm.Body = model.MESAJ;

            _mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            _mm.To.Add("ekncsmal@gmail.com");

            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);


            _smtpClient.Send(_mm);
            TempData["Başarılı"] = "Teşekürler En Kısa Zamanda Tarafınıza  Dönüş Yapılacaktır.";


            return RedirectToAction("Index");
        }
        public ActionResult MailSil(int id)
        {
            var mail = db.TBLILETISIM.Find(id);
            db.TBLILETISIM.Remove(mail);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}