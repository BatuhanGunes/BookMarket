using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Market.Models;

namespace Market.Controllers
{
    public class UyelikController : Controller
    {
        private string epostaTut;

        public ActionResult KayitOl()
        {
            return View();
        }


        // GET: Ana
        [HttpPost]
        public ActionResult KayitOl(Kisi Kisi)
        {

            using (Model1 ctx = new Model1())
            {
                Kisi Item = new Kisi();     // Kişi tablosunun nesnesini oluşturuyoruz.

                Item.Ad = Kisi.Ad;          //tablo bilgilerini bir forma aktarıyoruz.
                Item.Soyad = Kisi.Soyad;
                Item.Eposta = Kisi.Eposta;
                Item.TelNo = Kisi.TelNo;
                Item.Cinsiyet = Kisi.Cinsiyet;
                Item.Parola = Kisi.Parola;

                ctx.Kisis.Add(Item);     //Oluşturduğumuz formu kişi tablosuna ekliyoruz.

                ctx.SaveChanges();                                  //Model1 sınıfı için yapılan değişiklikleri yani sql işlemlerini kaydediyoruz.
                return RedirectToAction("GirisYap", "Uyelik");        //işlem bittikten sonra giriş yap sayfasına aktarıyoruz.
            }

        }


        // GET: Uyelik
        public ActionResult GirisYap(Kisi kisi) //parametre olarak Eposta çekiceğimiz sınıfa yönlendiriyoruz.
        {
            Session["Eposta"] = null;

            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                // Daha sonra Kisidan alınan bilgileri veritabanındaki veriler ile karşılaştırıyoruz.
                Kisi state = ctx.Kisis.Where(s => s.Eposta == kisi.Eposta
                                        && s.Parola == kisi.Parola).FirstOrDefault();

                if (state != null)
                {

                    Session["Eposta"] = state.Eposta.ToString();    // giriş işlemi yapıldıktan sonra kişinin bilgilerini tutmak ve kullanmak için sesion (yani kullanıcıdan gizli olarak) tutan bir değişkene atıyoruz.
                    epostaTut = state.Eposta.ToString();
                    return RedirectToAction("Profil", "Uyelik");
                }
                else
                {
                    //Eğer Yanlış giriş yapıldıysa bu sayfaya geri döndürüyoruz.
                    return View();
                }
            }
        }

        public ActionResult Control()
        {
            if (Session["Eposta"] != null)
            {
                return RedirectToAction("GirisYap", "Ana");
            }
            else
            {
                //Eğer Yanlış giriş yapıldıysa bu sayfaya geri döndürüyoruz.
                return View();
            }
        }

        public ActionResult Profil(Kisi kisi)
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                string ema = Convert.ToString(Session["Eposta"]);
                // Daha sonra Kisidan alınan bilgileri veritabanındaki veriler ile karşılaştırıyoruz.
                Kisi state = ctx.Kisis.Where(k => k.Eposta == ema).FirstOrDefault();

                List<Kisi> P = new List<Kisi>();
                P.Add(new Kisi { Ad = state.Ad, Soyad = state.Soyad, Eposta = state.Eposta, TelNo = state.TelNo, Cinsiyet = state.Cinsiyet, Parola = state.Parola });

                return View(P.ToList());
            }

        }
    }
}