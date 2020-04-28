using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class UrunController : Controller
    {

        private Model1 db = new Model1();

        // GET: Urunler
        public ActionResult Urunler(Kitap kitap)
        {

            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                string param = this.Request.QueryString["KitapAdi"];
                Kitap state;

                if (param != null)
                {
                    var stated = ctx.Kitaps.Where(s => s.KitapAdi.Contains(param)).ToList();
                    return View(stated);
                }
                else
                state = ctx.Kitaps.Where(s => s.KitapID == kitap.KitapID).FirstOrDefault();
                    return View(db.Kitaps);
                
            }  
        }
        
        public ActionResult TekUrun()
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                string param = this.Request.QueryString["Kitap"];
                int x = Convert.ToInt32(param);
                var state = ctx.Kitaps.Where(s => s.KitapID == x).ToList();

                if (state != null)
                {
                    return View(state);
                }
                else
                {
                    return RedirectToAction("Urunler", "Urun");
                }

            }
        }

        public ActionResult UrunEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UrunEkle(Kitap kitap)
        {
            using (Model1 ctx = new Model1())
            {
                Kitap Item = new Kitap();

                Item.KitapAdi = kitap.KitapAdi;          //tablo bilgilerini bir forma aktarıyoruz.
                Item.YazarAdi = kitap.YazarAdi;
                Item.YayinEvi = kitap.YayinEvi;
                Item.SayfaSayisi = kitap.SayfaSayisi;
                Item.BasimYili = kitap.BasimYili;
                Item.Fiyat = kitap.Fiyat;
                Item.Aciklama = kitap.Aciklama;
                Item.KitapTurID = kitap.KitapTurID;
                Item.KisiID = 1;
                Item.Durum = true;

                ctx.Kitaps.Add(Item);     //Oluşturduğumuz formu kişi tablosuna ekliyoruz.

                ctx.SaveChanges();                                  //Model1 sınıfı için yapılan değişiklikleri yani sql işlemlerini kaydediyoruz.
                return RedirectToAction("Urunler", "Urun");        //işlem bittikten sonra giriş yap sayfasına aktarıyoruz.
            }
        }

       
        public ActionResult Egitim()
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                
                var state = ctx.Kitaps.Where(s => s.KitapTurID == 1).ToList();

                return View(state);
            }

        }

        public ActionResult Edebiyat()
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
               
                var state = ctx.Kitaps.Where(s => s.KitapTurID == 2).ToList();

                return View(state);
            }
        }

        public ActionResult Arastirma()
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                
                var state = ctx.Kitaps.Where(s => s.KitapTurID == 3).ToList();

                return View(state);
            }
        }

        public ActionResult Cocuk()
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                
                var state = ctx.Kitaps.Where(s => s.KitapTurID == 4).ToList();

                return View(state);
            }
        }

        public ActionResult Din()
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                
                var state = ctx.Kitaps.Where(s => s.KitapTurID == 5).ToList();

                return View(state);
            }
        }

        
        public ActionResult Sanat()
        {
            using (Model1 ctx = new Model1())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                
                var state = ctx.Kitaps.Where(s => s.KitapTurID == 6).ToList();

                return View(state);
            }
        }
    }
}