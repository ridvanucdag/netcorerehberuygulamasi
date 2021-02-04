using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehberUygulamasi.Models;

namespace RehberUygulamasi.Controllers
{
    public class KisiController : Controller
    {
        RehberContext db = new RehberContext();

        public object DeliveryMethod { get; private set; }
        public object Isbodyhtml { get; private set; }

        public ActionResult Index()
        {
            var model = new KisiIndexModel
            {
                Kisiler = db.Kisiler.ToList(),
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KisiEkle
            {
                Kisi = new Kisi(),
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Ekle(Kisi kisi)
        {
            try
            {
                db.Kisiler.Add(kisi);
                db.SaveChanges();
                TempData["BasariliMesaj"] = "Rehbere ekleme işlemi başarılı bir şekilde gerçekleşti.";
            }
            catch (Exception)
            {
                TempData["HataliMesaj"] = "Hata! Lütfen ekleme işlemini tekrar deneyiniz.";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı";
                return RedirectToAction("Index");
            }

            var model = new KisiGuncelle
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
            };

            ViewBag.Sehirler = new SelectList(db.Sehirler.ToList(), "Id", "SehirAdi");

            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(Kisi kisi)
        {
            var guncelleme = db.Kisiler.Find(kisi.Id);
            if (guncelleme == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı";
                return RedirectToAction("Index");
            }
            guncelleme.Ad = kisi.Ad;
            guncelleme.Soyad = kisi.Soyad;
            guncelleme.EvTelefon = kisi.EvTelefon;
            guncelleme.IsTelefon = kisi.IsTelefon;
            guncelleme.EmailAdres = kisi.EmailAdres;
            guncelleme.Adres = kisi.Adres;
            guncelleme.SehirId = kisi.SehirId;

            db.SaveChanges();
            TempData["BasariliMesaj"] = "Rehber bilgisi başarılı bir şekilde güncellendi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detay(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi bulunamadı! Lütfen doğru kişiye tıklayınız";
                return RedirectToAction("Index");
            }
            var model = new KisiDetay
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
           };
            return View(model);
        }

        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi bulunamadı! Lütfen doğru kişiyi Seçin";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kişi, rehberden başarılı bir şekilde silinmiştir";
            return  RedirectToAction("Index");
        }

        public ActionResult MailGonder(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi==null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı";
                return RedirectToAction("Index");
            }
            return View(kisi);
        }

        [HttpPost]
        public ActionResult MailGonder(string MailAdres,string Baslik, string Mesaj)
        {
            try
            {
                var gonderimail = new MailAddress("ridvanucdag@gmail.com");
                var sifre = ""; /*Şifreyi yazmadığım içim mail göndermeyecektir. Mail adresinizin Şifresini girmeniz gerekecektir.*/
                var aliciMail = new MailAddress(MailAdres);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(gonderimail.Address, sifre)
                
               };

                using (var msg = new MailMessage(gonderimail, aliciMail)
                {
                    IsBodyHtml = true,
                    Subject=Baslik,
                    Body=Mesaj
                })

                {
                    smtp.Send(msg);
                }
                TempData["BasariliMesaj"] = "Mail başarılı bir şekilde gönderildi";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["HataliMesaj"] = "Mail gönderme sırasında hata oluştu!";
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult KonumAl()
        {
            return View();
        }
    }
}
