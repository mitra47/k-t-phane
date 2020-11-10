using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvckutuphane.Models.Entity;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using System.Net;
using Mvckutuphane.Models.Sınıflarım;

namespace Mvckutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        string Message = "";
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult GirisYap(TBLUYE uye)
        {


            var bilgiler = db.TBLUYE.FirstOrDefault(x => x.MAIL == uye.MAIL && x.SIFRE == uye.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["MAIL"] = bilgiler.MAIL.ToString();
                //var userRoles = (string[])Session["RolAdi"];

                var UyeRol = bilgiler.TBLUYEROL.FirstOrDefault(x => x.RolID == 1);
                if (UyeRol != null)
                {
                    return RedirectToAction("Index", "panelim");
                }
                var AdminRol = bilgiler.TBLUYEROL.FirstOrDefault(x => x.RolID == 2);
                if (AdminRol != null)
                {
                    return RedirectToAction("Index", "istatistik");
                }

                else
                {
                    Message = "Giriş Bilgileri Hatalı";
                }

            }
            else
            {
                Message = "Giriş Bilgileri Hatalı";
            }

            ViewBag.Message = Message;
            return View();



        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "vitrin");
        }
        [HttpGet]

        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
       

        public ActionResult ResetPassword(TBLUYE z)

        {
            var model = db.TBLUYE.Where(x => x.MAIL == z.MAIL).FirstOrDefault();
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.SIFRE = rastgele.ToString().Substring(0, 8);
                db.SaveChanges();
                SmtpClient client = new SmtpClient("mail.google.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("ekncsmal@gmail.com", "Şifre Sıfırlama");
                mail.To.Add("ahmet@gmail.com");
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Yenileme";
                mail.Body += "Merhaba" + model.AD + "<br/> Kullanıcı Adınız=" + model.KULLANICIADI + "<br/> Şifreniz=" + model.SIFRE;
                NetworkCredential net = new NetworkCredential("ekncsmal@gmail.com", "Derik.47");
                client.Credentials = net;
                client.Send(mail);

                return RedirectToAction("Login", "Index");
            }
            ViewBag.hata = "Böyle Bir Mail Adresi bulunamadı.";
            return View();
        }
    }
}