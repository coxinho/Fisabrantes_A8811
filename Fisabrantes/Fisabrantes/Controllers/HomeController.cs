using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fisabrantes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A fisioterapia atua em três bases principais:";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto da clínica";

            return View();
        }
    }
}
