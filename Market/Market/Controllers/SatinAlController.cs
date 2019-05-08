using Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class SatinAlController : Controller
    {
        private Model db = new Model();

        // GET: SatinAl
        public ActionResult SatinAl()
        {
            using (Model ctx = new Model())   //veritabanı bağlantısı oluşturuyoruz. Burada Model1 bizim veri tabanını uygulamaya eklerken verdiğimiz isim
            {
                string param = this.Request.QueryString["Kitap"];
                int x = Convert.ToInt32(param);
                var state = ctx.Kitap.Where(s => s.KitapID == x).ToList();

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
    }
}