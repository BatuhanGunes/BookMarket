using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class AnaController : Controller
    {
        // GET: Ana
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }
    }
}